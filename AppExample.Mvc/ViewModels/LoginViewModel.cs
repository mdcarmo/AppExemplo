using System.ComponentModel.DataAnnotations;

namespace AppExample.Mvc.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "O campo e-mail é obrigatório")]
		[EmailAddress(ErrorMessage = "E-mail inválido")]
		[Display(Name = "E-mail")]
		public string Email { get; set; }
		[Required(ErrorMessage = "O campo senha é obrigatório")]
		[MaxLength(20, ErrorMessage = "O campo senha deve ter no máximo 20 caracteres")]
		[MinLength(5, ErrorMessage = "O campo Senha deve ter no mínimo 5 caracteres")]
		[Display(Name = "Senha")]
		public string Password { get; set; }
	}
}