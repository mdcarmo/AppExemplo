using AppExample.Service.Domain.Entities;
using AppExample.Service.Domain.Repositories;

namespace AppExample.Service.DataAccess.Repositories
{
	public class ContactRepository : RepositoryBase<Contact>, IContactRepository
	{
	}
}
