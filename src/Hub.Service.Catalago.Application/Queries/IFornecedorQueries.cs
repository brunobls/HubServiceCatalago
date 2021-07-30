using Hub.Service.Catalago.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Service.Catalago.Application.Queries
{
    public interface IFornecedorQueries
    {
        Task<IEnumerable<FornecedorDTO>> ObterTodosFornecedores();
        Task<FornecedorDTO> ObterFornecedor(Guid id);
        Task<IEnumerable<ProfissaoDTO>> ObterTodasProfissoes();
        Task<ProfissaoDTO> ObterProfissao(Guid id);
    }
}
