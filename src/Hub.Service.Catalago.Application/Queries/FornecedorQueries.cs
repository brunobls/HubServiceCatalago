using Hub.Service.Catalago.Application.Queries.ViewModels;
using Hub.Service.Catalago.Domain;
using Hub.Service.Core.Communication.Mediator;
using Hub.Service.Core.Messages.CommonMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub.Service.Catalago.Application.Queries
{
    public class FornecedorQueries : IFornecedorQueries
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public FornecedorQueries(IFornecedorRepository fornecedorRepository, IMediatorHandler mediatorHandler)
        {
            _fornecedorRepository = fornecedorRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<FornecedorDTO> ObterFornecedor(Guid id)
        {
            var fornecedor = await _fornecedorRepository.ObterFornecedorPorId(id);

            if (fornecedor == null) {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(GetType().Name, "O id do fornecedor não está cadastrado na base de dados", id));
                return null;
            };

            return new FornecedorDTO {
                Id = fornecedor.Id,
                DataCadastro = fornecedor.DataCadastro,
                Nome = fornecedor.Nome,
                ProfissaoNome = fornecedor.Profissao.Nome,
                ProfissaoId = fornecedor.Profissao.Id
            };
        }

        public async Task<IEnumerable<FornecedorDTO>> ObterTodosFornecedores()
        {
            var fornecedores = await _fornecedorRepository.ObterTodosFornecedores();

            if (!fornecedores.Any()) {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(GetType().Name, "Não foi encontrado nenhum fornecedor na base de dados"));
                return null;
            };

            var fornecedoresDTO = new List<FornecedorDTO>();

            foreach (var fornecedor in fornecedores)
            {
                fornecedoresDTO.Add(new FornecedorDTO { 
                    Id = fornecedor.Id,
                    DataCadastro = fornecedor.DataCadastro,
                    Nome = fornecedor.Nome,
                    ProfissaoNome = fornecedor.Profissao.Nome,
                    ProfissaoId = fornecedor.Profissao.Id
                });
            }

            return fornecedoresDTO;
        }

        public async Task<ProfissaoDTO> ObterProfissao(Guid id) {
            var profissao = await _fornecedorRepository.ObterProfissaoPorId(id);

            if (profissao == null) return null;

            return new ProfissaoDTO {
                Id = profissao.Id,
                DataCadastro = profissao.DataCadastro,
                Nome = profissao.Nome
            };        
        }

        public async Task<IEnumerable<ProfissaoDTO>> ObterTodasProfissoes()
        {
            var profissoes = await _fornecedorRepository.ObterTodasProfissoes();

            if (!profissoes.Any()) return null;

            var profissoesDTO = new List<ProfissaoDTO>();

            foreach (var profissao in profissoes)
            {
                profissoesDTO.Add(new ProfissaoDTO
                {
                    Id = profissao.Id,
                    DataCadastro = profissao.DataCadastro,
                    Nome = profissao.Nome
                });
            }

            return profissoesDTO;
        }
    }
}
