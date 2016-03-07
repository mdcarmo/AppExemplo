using System.ComponentModel.DataAnnotations;

namespace AppExample.Mvc.ViewModels
{
	public class UserViewModel
	{
		[Required(ErrorMessage = "O campo Nome é obrigatório")]
		[StringLength(100, MinimumLength = 5, ErrorMessage = "O campo Nome deve ter entre 5 e 100 caracteres")]
		[Display(Name = "Nome")]
		public string Name { get; set; }
		[Required(ErrorMessage = "O campo E-mail é obrigatório")]
		[EmailAddress(ErrorMessage = "E-mail inválido")]
		[Display(Name = "E-mail")]
		public string Email { get; set; }

		[Required(ErrorMessage = "O campo Senha é obrigatório")]
		[DataType(DataType.Password)]
		[StringLength(20, MinimumLength = 5, ErrorMessage = "O campo Senha deve ter entre 5 e 20 caracteres")]
		[Display(Name = "Senha")]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "As senhas não são iguais")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirmar Senha")]
		public string ConfirmPassword { get; set; }
	}
}