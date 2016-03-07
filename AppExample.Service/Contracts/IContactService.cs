using AppExample.Service.Dto;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AppExample.Service.Contracts
{
	[ServiceContract]
	public interface IContactService
	{
		[OperationContract]
		void AddContact(ContactDto contactDto);

		[OperationContract]
		void UpdateContact(ContactDto contactDto);

		[OperationContract]
		void DeleteContact(ContactDto contactDto);

		[OperationContract]
		ContactDto FindById(Guid id);

		[OperationContract]
		IEnumerable<ContactDto> FindAll();

		[OperationContract]
		IEnumerable<ContactDto> FindByName(string name);
	}
}
