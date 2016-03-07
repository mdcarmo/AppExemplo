using AppExample.Service.Domain.Exceptions;
using System;

namespace AppExample.Service.Domain.Entities
{
	public class Contact
	{
		#region Construtores

        protected Contact() { }
		public Contact(string name, string email, string phone)
        {
			if (string.IsNullOrEmpty(name)) throw new DomainException("O nome do contato deve ser fornecido");

			if (string.IsNullOrEmpty(phone)) throw new DomainException("O número do telefone deve ser fornecido");

			if (!(phone.Length == 10)) throw new DomainException("O número do telefone deve ter 10 caracteres");

			ContactId = Guid.NewGuid();
			Name = name;
			Email = email;
			Phone = phone;
        }
        #endregion

		#region [ Properties ]
		public Guid ContactId { get; protected set; }
		public string Name { get; protected set; }
		public string Email { get; protected set; }
		public string Phone { get; protected set; }
		#endregion

		#region [ Methods ]

		public void UpdateContact(string name, string email, string phone)
		{
			if (string.IsNullOrEmpty(name)) throw new DomainException("O nome do contato deve ser fornecido");

			Name = name;
			Email = email;
			Phone = phone;
		}

		public override string ToString()
		{
			return Name;
		}
		#endregion
	}
}
