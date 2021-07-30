using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Service.Catalago.Application.Queries.ViewModels
{
    public class FornecedorDTO
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public string ProfissaoNome { get; set; }
        public Guid ProfissaoId { get; set; }
    }
}
