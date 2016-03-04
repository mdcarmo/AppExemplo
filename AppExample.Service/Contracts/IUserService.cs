using AppExample.Service.Dto;
using System.ServiceModel;

namespace AppExample.Service.Contracts
{
	[ServiceContract]
	public interface IUserService
	{
		[OperationContract]
		void AddNewUser(UserDto userDto);

		[OperationContract]
		void ChangePassword(ChangePasswordDto changePasswordDto);
	}
}
