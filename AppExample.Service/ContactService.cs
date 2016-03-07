using AppExample.Service.Contracts;
using AppExample.Service.DataAccess.Repositories;
using AppExample.Service.Domain.Entities;
using AppExample.Service.Domain.Exceptions;
using AppExample.Service.Domain.Repositories;
using AppExample.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppExample.Service
{
	public class ContactService : IContactService
	{
		private readonly IContactRepository _contactRepository;
		public ContactService()
		{
			_contactRepository = new ContactRepository();
		}

		public void AddContact(ContactDto contactDto)
		{
			var contactDomain = new Contact(contactDto.Name,contactDto.Email,contactDto.Phone);
			_contactRepository.Add(contactDomain);
		}

		public void UpdateContact(ContactDto contactDto)
		{
			var contactBD = _contactRepository.GetById(contactDto.Id);

			if (contactBD == null)
				throw new DomainException("Este contato foi excluído ou não existe");

			contactBD.UpdateContact(contactDto.Name,contactDto.Email,contactDto.Phone);

			_contactRepository.Update(contactBD);
		}

		public void DeleteContact(ContactDto contactDto)
		{
			var contactBD = _contactRepository.GetById(contactDto.Id);

			if (contactBD == null)
				throw new DomainException("Este contato foi excluído ou não existe");

			_contactRepository.Remove(contactBD);
		}

		public ContactDto FindById(Guid id)
		{
			var contactBD = _contactRepository.GetById(id);

			if (contactBD == null)
				throw new DomainException("Este contato foi excluído ou não existe");

			var contactDto = new ContactDto();
			contactDto.Id = contactBD.ContactId;
			contactDto.Name = contactBD.Name;
			contactDto.Email = contactBD.Email;
			contactDto.Phone = contactBD.Phone;

			return contactDto;
		}

		public IEnumerable<ContactDto> FindAll()
		{
			var contactReturn = new List<ContactDto>();

			foreach (var item in _contactRepository.GetAll())
			{
				var contactDto = new ContactDto();
				contactDto.Id = item.ContactId;
				contactDto.Name = item.Name;
				contactDto.Email = item.Email;
				contactDto.Phone = item.Phone;
				contactReturn.Add(contactDto);
			}

			return contactReturn;
		}

		public IEnumerable<ContactDto> FindByName(string name)
		{
			var contactReturn = new List<ContactDto>();

			foreach (var item in _contactRepository.Find(x => x.Name.Contains(name)).ToList())
			{
				var contactDto = new ContactDto();
				contactDto.Id = item.ContactId;
				contactDto.Name = item.Name;
				contactDto.Email = item.Email;
				contactDto.Phone = item.Phone;
				contactReturn.Add(contactDto);
			}

			return contactReturn;
		}
	}
}
