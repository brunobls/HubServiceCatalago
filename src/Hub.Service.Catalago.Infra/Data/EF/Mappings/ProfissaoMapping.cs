using Hub.Service.Catalago.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hub.Service.Catalago.Infra.Data.EF.Mappings
{
    public class ProfissaoMapping : IEntityTypeConfiguration<Profissao>
    {
        public void Configure(EntityTypeBuilder<Profissao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("VARCHAR(30)");

            // 1 : N => Profissao : Fornecedores
            builder.HasMany(p => p.Fornecedores)
                .WithOne(f => f.Profissao)
                .HasForeignKey(f => f.ProfissaoId);

            builder.ToTable("Profissoes");
        }
    }
}
