using AutoMapper;
using Hub.Service.Catalago.Api.ViewModel;
using Hub.Service.Catalago.Api.Requests;
using Hub.Service.Catalago.Application.Commands;
using System;

namespace Hub.Service.Catalago.Api.AutoMapper
{
    public class RequestToCommandProfile : Profile
    {
        public RequestToCommandProfile() {
            CreateMap<RequestFornecedorCreate, AdicionarFornecedorCommand>()
                .ConstructUsing(r => new AdicionarFornecedorCommand(Guid.NewGuid(), r.FornecedorNome, r.ProfissaoId));
        }
    }
}
