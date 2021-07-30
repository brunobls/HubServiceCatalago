using FluentValidation;
using FluentValidation.Results;
using Hub.Service.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Service.Catalago.Application.Commands
{
    public class AdicionarFornecedorCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid ProfissaoId { get; set; }
     
        public AdicionarFornecedorCommand(Guid id, string nome, Guid profissaoId)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            ProfissaoId = profissaoId;
        }

        public override bool isValid()
        {
            ValidationResult = new AdicionarFornecedorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarFornecedorValidation : AbstractValidator<AdicionarFornecedorCommand>
    {
        public AdicionarFornecedorValidation()
        {
            RuleFor(f => f.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do fornecedor está vazio");

            RuleFor(f => f.Nome)
                .NotEmpty()
                .WithMessage("Nome do fornecedor está vazio");

            RuleFor(f => f.ProfissaoId)
                .NotEmpty()
                .WithMessage("O id da profissão está vazio");
        }
    }
}
