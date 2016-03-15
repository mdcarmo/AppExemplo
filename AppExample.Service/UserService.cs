using AppExample.Service.Common;
using AppExample.Service.Contracts;
using AppExample.Service.DataAccess.Repositories;
using AppExample.Service.Domain.Entities;
using AppExample.Service.Domain.Exceptions;
using AppExample.Service.Domain.Repositories;
using AppExample.Service.Dto;

namespace AppExample.Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		public UserService()
        {
			_userRepository = new UserRepository();
        }

		public void AddNewUser(UserDto userDto)
		{
			var userDomain = new User(userDto.Name, userDto.Email, userDto.Password); 

			if (_userRepository.FindByEmail(userDto.Email) != null)
				throw new DomainException("Este e-mail já foi cadastrado!");

			userDomain.EncryptedPassword(EncryptHelper.Encrypt(userDto.Password));

			_userRepository.Add(userDomain);
		}

		public void ChangePassword(ChangePasswordDto changePasswordDto)
		{
			var userBd = _userRepository.FindByEmail(changePasswordDto.Email);

			if (userBd == null)
				throw new DomainException("E-mail não cadastrado");

			userBd.ChangePassword(EncryptHelper.Encrypt(changePasswordDto.Password), changePasswordDto.PasswordNew, EncryptHelper.Encrypt(changePasswordDto.PasswordNew), EncryptHelper.Encrypt(changePasswordDto.ConfirmPasswordNew));

			_userRepository.Update(userBd);
		}
	}
}