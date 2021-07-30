using System;
using System.Collections.Generic;
using System.Linq;
using Hub.Service.Core.Communication.Mediator;
using Hub.Service.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hub.Service.Catalago.Api.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHandler;

        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        protected ControllerBase(INotificationHandler<DomainNotification> notifications, 
                                 IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected IEnumerable<object> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(n => new {n.Value, n.DomainNotificationId, n.AggregateId}).ToList();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }

        protected void NotificarErro(string codigo, string mensagem, Guid id)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem, id));
        }
    }
}