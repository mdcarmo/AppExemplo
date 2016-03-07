using System.ComponentModel.DataAnnotations;

namespace AppExample.Mvc.ViewModels
{
	public class AlterPasswordViewModel
	{
		[Required(ErrorMessage = "O campo Senha Atual é obrigatório")]
		[DataType(DataType.Password)]
		[StringLength(20, MinimumLength = 5, ErrorMessage = "O campo Senha Atual deve ter entre 5 e 20 caracteres")]
		[Display(Name = "Senha Atual")]
		public string CurrentPassword { get; set; }

		[Required(ErrorMessage = "O campo Nova Senha é obrigatório")]
		[DataType(DataType.Password)]
		[StringLength(20, MinimumLength = 5, ErrorMessage = "O campo Nova Senha deve ter entre 5 e 20 caracteres")]
		[Display(Name = "Nova Senha")]
		public string PasswordNew { get; set; }

		[Compare("PasswordNew", ErrorMessage = "As senhas não são iguais")]
		[Display(Name = "Confirmar Nova Senha")]
		[DataType(DataType.Password)]
		public string ConfirmPasswordNew { get; set; }
	}
}