using Hub.Service.Catalago.Domain;
using Hub.Service.Core.Communication.Mediator;
using Hub.Service.Core.Messages;
using Hub.Service.Core.Messages.CommonMessages.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hub.Service.Catalago.Application.Commands
{
    public class FornecedorCommandHandler : IRequestHandler<AdicionarFornecedorCommand, bool>
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public FornecedorCommandHandler(IFornecedorRepository fornecedorRepository, IMediatorHandler mediatorHandler)
        {
            _fornecedorRepository = fornecedorRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(AdicionarFornecedorCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var profissao = await _fornecedorRepository.ObterProfissaoPorId(message.ProfissaoId);

            if (profissao == null)
            {
                await _mediatorHandler.PublicarNotificacao( new DomainNotification(message.MessageType, "O id da profissão não está cadastrado na base de dados", message.AggregateId));
                return false;
            }

            var fornecedor = new Fornecedor(message.Nome, profissao.Id, DateTime.Now);

            _fornecedorRepository.AdicionarFornecedor(fornecedor);

            return await _fornecedorRepository.UnitOfWork.Commit();
        }

        private bool ValidarComando(Command message)
        {
            if (message.isValid()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage, message.AggregateId));
            }

            return false;
        }
    }
}
