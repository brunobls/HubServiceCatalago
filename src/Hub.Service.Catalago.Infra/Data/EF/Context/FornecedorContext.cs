using Hub.Service.Core.Data;
using Hub.Service.Catalago.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Service.Catalago.Infra.Data.EF.Context
{
    public class FornecedorContext : DbContext, IUnitOfWork
    {
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Profissao> Profissoes { get; set; }
        public FornecedorContext(DbContextOptions<FornecedorContext> options) : base(options) { }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FornecedorContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
