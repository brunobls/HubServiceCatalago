using AutoMapper;
using System;
using Hub.Service.Catalago.Application.Queries.ViewModels;
using Hub.Service.Catalago.Api.ViewModel;

namespace Hub.Service.Catalago.Api.AutoMapper
{
    public class DtoToViewModelProfile : Profile
    {
        public DtoToViewModelProfile() {
            CreateMap<FornecedorDTO, FornecedorViewModelV1>()
                .ConstructUsing(f => new FornecedorViewModelV1(f.Nome, f.Id, f.ProfissaoNome, f.ProfissaoId));

            CreateMap<ProfissaoDTO, ProfissaoViewModelV1>()
                .ConstructUsing(p => new ProfissaoViewModelV1(p.Id, p.Nome));
        }
    }
}
