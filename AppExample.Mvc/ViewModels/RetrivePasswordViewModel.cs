using System.ComponentModel.DataAnnotations;

namespace AppExample.Mvc.ViewModels
{
	public class RetrivePasswordViewModel
	{
		[Required(ErrorMessage = "O campo E-mail é obrigatório")]
		[EmailAddress(ErrorMessage = "E-mail inválido")]
		[Display(Name = "E-mail")]
		public string Email { get; set; }

		[Display(Name = "Senha Recuperada")]
		public string PasswordRecovered { get; set; }
	}
}