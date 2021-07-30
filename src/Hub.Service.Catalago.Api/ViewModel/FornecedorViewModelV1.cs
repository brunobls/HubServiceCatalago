using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Service.Catalago.Api.ViewModel
{
    public class FornecedorViewModelV1
    {
        public string FornecedorNome { get; set; }
        public Guid FornecedorId { get; set; }
        public string ProfissaoNome { get; set; }
        public Guid ProfissaoId { get; set; }
        public FornecedorViewModelV1(string fornecedorNome, Guid fornecedorId, string profissaoNome, Guid profissaoId)
        {
            FornecedorNome = fornecedorNome;
            FornecedorId = fornecedorId;
            ProfissaoNome = profissaoNome;
            ProfissaoId = profissaoId;
        }
    }
}
