using AppExample.Service.Dto;
using System.ServiceModel;

namespace AppExample.Service.Contracts
{
	[ServiceContract]
	public interface IAuthenticationService
	{
		[OperationContract]
		UserDto AuthenticateUser(UserDto userDto);

		//O ideal era recuperar a senha por e-mail, mas por aplicação de teste, vou voltar diretamente ao usuário na tela
		[OperationContract]
		string RetrivePassword(string email);
	}
}
