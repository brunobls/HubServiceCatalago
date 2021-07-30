using Hub.Service.Core.Data;
using Hub.Service.Catalago.Domain;
using Hub.Service.Catalago.Infra.Data.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Hub.Service.Catalago.Infra.Data.Repository
{
    public class FornecedorRepositorySqlEf : IFornecedorRepository
    {
        private readonly FornecedorContext _context;

        public FornecedorRepositorySqlEf(FornecedorContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void AdicionarFornecedor(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
        }

        public async Task<Fornecedor> ObterFornecedorPorId(Guid id)
        {
            var fornecedor = await _context.Fornecedores.Include(f => f.Profissao).FirstOrDefaultAsync(f => f.Id == id);
            return fornecedor;
        }

        public async Task<Profissao> ObterProfissaoPorId(Guid id)
        {
            var profissao = await _context.Profissoes.FirstOrDefaultAsync(p => p.Id == id);
            return profissao;
        }

        public async Task<IEnumerable<Profissao>> ObterTodasProfissoes()
        {
            var profissoes = await _context.Profissoes.ToListAsync();
            return profissoes;
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodosFornecedores()
        {
            var fornecedores = await _context.Fornecedores.Include(f => f.Profissao).ToListAsync();
            return fornecedores;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
