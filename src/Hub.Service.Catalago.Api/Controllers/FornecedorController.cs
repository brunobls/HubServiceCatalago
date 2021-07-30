using AutoMapper;
using Hub.Service.Catalago.Api.Requests;
using Hub.Service.Catalago.Api.ViewModel;
using Hub.Service.Catalago.Application.Commands;
using Hub.Service.Catalago.Application.Queries;
using Hub.Service.Core.Communication.Mediator;
using Hub.Service.Core.Messages.CommonMessages.Notifications;
using Hub.Service.Core.Utilities;
using Hub.Service.Core.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hub.Service.Catalago.Api.Controllers
{

    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorQueries _fornecedorQueries;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediatorHandler;

        public FornecedorController(INotificationHandler<DomainNotification> notifications, 
                                    IFornecedorQueries fornecedorQueries, 
                                    IMapper mapper, 
                                    IMediatorHandler mediatorHandler) : base(notifications, mediatorHandler)
        {
            _fornecedorQueries = fornecedorQueries;
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet]
        [Route("/api/v1/fornecedores/get-all")]
        public async Task<IActionResult> GetFornecedores() {
            try
            {
                var fornecedoresDTO = await _fornecedorQueries.ObterTodosFornecedores();

                if (OperacaoValida())
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Fornecedores encontrados com sucesso!",
                        Success = true,
                        Data = _mapper.Map<IEnumerable<FornecedorViewModelV1>>(fornecedoresDTO)
                    });
                }

                return BadRequest(ObterMensagensErro());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }

        [HttpGet]
        [Route("/api/v1/fornecedores/get/{id}")]
        public async Task<IActionResult> GetFornecedores(Guid id)
        {
            try
            {
                var fornecedorDTO = await _fornecedorQueries.ObterFornecedor(id);

                if (OperacaoValida())
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Fornecedor encontrado com sucesso!",
                        Success = true,
                        Data = _mapper.Map<FornecedorViewModelV1>(fornecedorDTO)
                    });
                }

                return BadRequest(ObterMensagensErro());
            }
            catch (System.Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPost]
        [Route("/api/v1/fornecedores/create")]
        public async Task<IActionResult> Create([FromBody] RequestFornecedorCreate requestFornecedorCreate)
        {
            try
            {
                var command = _mapper.Map<AdicionarFornecedorCommand>(requestFornecedorCreate);

                await _mediatorHandler.EnviarComando(command);

                if (OperacaoValida())
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Fornecedor criado com sucesso!",
                        Success = true
                    });
                }

                return BadRequest(ObterMensagensErro());
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/fornecedores/profissoes/get-all")]
        public async Task<IActionResult> GetProfissoes()
        {
            try
            {
                var profissoesDTO = await _fornecedorQueries.ObterTodasProfissoes();

                return Ok(new ResultViewModel
                {
                    Message = "Profissões encontradas com sucesso!",
                    Success = true,
                    Data = _mapper.Map<IEnumerable<ProfissaoViewModelV1>>(profissoesDTO)
                });
            }
            catch (System.Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/fornecedores/profissoes/get/{id}")]
        public async Task<IActionResult> GetProfissoes(Guid id)
        {
            try
            {
                var profissaoDTO = await _fornecedorQueries.ObterProfissao(id);

                return Ok(new ResultViewModel
                {
                    Message = "Profissão encontrada com sucesso!",
                    Success = true,
                    Data = _mapper.Map<ProfissaoViewModelV1>(profissaoDTO)
                });
            }
            catch (System.Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
