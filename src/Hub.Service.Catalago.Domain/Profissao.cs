using Hub.Service.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Service.Catalago.Domain
{
    public class Profissao : Entity
    {
        public string Nome { get; private set; }
        public DateTime DataCadastro { get; private set; }

        // EF Rel.
        public virtual ICollection<Fornecedor> Fornecedores { get; set; }
        protected Profissao() { }

        public Profissao(string nome, DateTime dataCadastro)
        {
            Nome = nome;
            DataCadastro = dataCadastro;
        }
    }
}
