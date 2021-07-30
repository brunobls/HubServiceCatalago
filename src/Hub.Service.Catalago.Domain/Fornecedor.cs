using Hub.Service.Core.Domain;
using System;

namespace Hub.Service.Catalago.Domain
{
    public class Fornecedor : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Guid ProfissaoId { get; private set; }
        public DateTime DataCadastro { get; private set; }

        //EF Relational
        public virtual Profissao Profissao { get; private set; }
        protected Fornecedor(){}

        public Fornecedor(string nome, Guid profissaoId, DateTime dataCadastro)
        {
            Nome = nome;
            ProfissaoId = profissaoId;
            DataCadastro = dataCadastro;
        }
    }
}
