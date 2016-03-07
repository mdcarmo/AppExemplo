using AppExample.Service.Common;
using AppExample.Service.Contracts;
using AppExample.Service.DataAccess.Repositories;
using AppExample.Service.Domain.Exceptions;
using AppExample.Service.Domain.Repositories;
using AppExample.Service.Dto;

namespace AppExample.Service
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly IUserRepository _userRepository;
		public AuthenticationService()
        {
			_userRepository = new UserRepository();
        }

		public UserDto AuthenticateUser(UserDto userDto)
		{
			var userBD = _userRepository.FindByEmail(userDto.Email);

			if (userBD == null)
				throw new DomainException("O usuário não existe");

			if (userBD.Password != EncryptHelper.Encrypt(userBD.Password))
				throw new DomainException("Senha incorreta");

			userDto.Name = userBD.Name;

			return userDto;
		}

		public string RetrivePassword(string email)
		{
			var userBD = _userRepository.FindByEmail(email);

			if (userBD == null)
				throw new DomainException("O e-mail fornecido não pertence a nenhum usuário");

			return EncryptHelper.Decrypt(userBD.Password);
		}
	}
}
