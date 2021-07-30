using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Service.Catalago.Api.ViewModel
{
    public class ProfissaoViewModelV1
    {
        public ProfissaoViewModelV1(Guid profissaoId, string profissaoNome)
        {
            ProfissaoId = profissaoId;
            ProfissaoNome = profissaoNome;
        }

        public Guid ProfissaoId { get; set; }
        public string ProfissaoNome { get; set; }
    }
}
