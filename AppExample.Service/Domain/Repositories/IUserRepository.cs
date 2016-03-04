using AppExample.Service.Domain.Entities;

namespace AppExample.Service.Domain.Repositories
{
	public interface IUserRepository : IRepositoryBase<User>
	{
		User FindByEmail(string email);
	}
}
