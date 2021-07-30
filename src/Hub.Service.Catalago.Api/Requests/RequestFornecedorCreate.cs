using System;
using System.ComponentModel.DataAnnotations;

namespace Hub.Service.Catalago.Api.Requests
{
    public class RequestFornecedorCreate
    {
        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(30, ErrorMessage = "O nome deve ter no máximo 30 caracteres.")]
        public string FornecedorNome { get; set; }

        [Required(ErrorMessage = "O ProfissaoId não pode ser vazio.")]
        public Guid ProfissaoId { get; set; }
    }
}
