using Hub.Service.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Service.Catalago.Domain
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorPorId(Guid id);
        Task<IEnumerable<Fornecedor>> ObterTodosFornecedores();
        Task<Profissao> ObterProfissaoPorId(Guid id);
        Task<IEnumerable<Profissao>> ObterTodasProfissoes();
        void AdicionarFornecedor(Fornecedor fornecedor);
    }
}
