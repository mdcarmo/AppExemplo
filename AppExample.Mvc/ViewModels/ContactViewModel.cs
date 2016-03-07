using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AppExample.Mvc.ViewModels
{
	public class ContactViewModel
	{
		[HiddenInput]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "O campo Nome é obrigatório")]
		[StringLength(100, MinimumLength = 5, ErrorMessage = "O campo Nome deve ter entre 5 e 100 caracteres")]
		[Display(Name = "Nome")]
		public string Name { get; set; }

		[Required(ErrorMessage = "O campo E-mail é obrigatório")]
		[EmailAddress(ErrorMessage = "E-mail inválido")]
		[Display(Name = "E-mail")]

		public string Email { get; set; }

		[Required(ErrorMessage = "O campo Telefone é obrigatório")]
		[StringLength(10, MinimumLength = 10, ErrorMessage = "O campo Telefone deve ter 10 caracteres")]
		[Display(Name = "Telefone")]
		public string Phone { get; set; }
	}
}