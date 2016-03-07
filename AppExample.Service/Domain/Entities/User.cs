using AppExample.Service.Domain.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace AppExample.Service.Domain.Entities
{
	public class User
	{
		#region [ Constructor ]
		protected User()
		{

		}

		public User(string name, string email, string password)
		{
			if (string.IsNullOrEmpty(name)) throw new DomainException("O nome do usuário deve ser fornecido");

			if (string.IsNullOrEmpty(email)) throw new DomainException("O e-mail do usuário deve ser fornecido");

			if (string.IsNullOrEmpty(password)) throw new DomainException("A senha do usuário deve ser fornecida");

			if (password.Length < 5 || password.Length > 20) throw new DomainException("A senha do usuário deve ter entre 5 e 20 caracteres");

			if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
				throw new DomainException("E-mail inválido");

			UserId = Guid.NewGuid();
			Name = name;
			Email = email;
			Password = password;
		} 
		#endregion

		#region [ Properties ]

		public Guid UserId { get; protected set; }
		public string Name { get; protected set; }
		public string  Email { get; protected set; }
		public string Password { get; protected set; }
		public DateTime DateRegister { get; protected set; }

		#endregion

		#region [ Methods ]

		public void EncryptedPassword(string encryptedPassword)
		{
			Password = encryptedPassword;
		}

		public void ChangePassword(string currentEncryptedPassword, string newPassword, string newEncryptedPassword, string confirmNewEncryptedPassword)
		{
			if (string.IsNullOrEmpty(newPassword)) throw new DomainException("A senha atual do usuário deve ser fornecida");

			if (newPassword.Length < 5 || newPassword.Length > 20) throw new DomainException("A senha atual do usuário deve ter entre 5 e 20 caracteres");

			if (newEncryptedPassword != confirmNewEncryptedPassword) throw new DomainException("A nova senha e a confirmação de nova senha não são iguais");

			if (Password != currentEncryptedPassword) throw new DomainException("A senha atual fornecida está incorreta");

			Password = newEncryptedPassword;
		}

		public override string ToString()
		{
			return Name;
		}

		#endregion
	}
}
