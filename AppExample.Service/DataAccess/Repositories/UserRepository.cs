using AppExample.Service.Domain.Entities;
using AppExample.Service.Domain.Repositories;
using System.Linq;

namespace AppExample.Service.DataAccess.Repositories
{
	public class UserRepository: RepositoryBase<User>, IUserRepository
	{
		public User FindByEmail(string email)
		{
			return _dbContext.Users.FirstOrDefault(x => x.Email == email);
		}
	}
}
