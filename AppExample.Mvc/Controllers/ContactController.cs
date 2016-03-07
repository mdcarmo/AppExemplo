using AppExample.Mvc.ContactService;
using AppExample.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Mvc;

namespace AppExample.Mvc.Controllers
{
	 [Authorize]
    public class ContactController : BaseController
    {
		#region [ Index ]
		public ActionResult Index()
		{
			var contactViewModel = new List<ContactViewModel>();
			using (ContactServiceClient _service = new ContactServiceClient())
			{
				var contacts = _service.FindAll();
				foreach (var item in contacts)
				{
					ContactViewModel contactVM = new ContactViewModel();
					contactVM.Id = item.Id;
					contactVM.Name = item.Name;
					contactVM.Email = item.Email;
					contactVM.Phone = item.Phone;
					contactViewModel.Add(contactVM);
				}
			}

			return View(contactViewModel);
		} 
		#endregion

		#region [ Create ]
		public ActionResult Create()
		{
			return View();
		} 
		#endregion

		#region [ Create(ContactViewModel model) ]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ContactViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using (ContactServiceClient _service = new ContactServiceClient())
					{
						ContactDto contactDto = new ContactDto();
						contactDto.Name = model.Name;
						contactDto.Email = model.Email;
						contactDto.Phone = model.Phone;

						_service.AddContact(contactDto);
					}

					return RedirectToAction("Index");
				}
			}
			catch (FaultException faultException)
			{
				ModelState.AddModelError("", faultException.Message);
			}

			return View(model);
		} 
		#endregion

		#region [ Edit(Guid id) ]
		public ActionResult Edit(Guid id)
		{
			var model = new ContactViewModel();
			using (ContactServiceClient _service = new ContactServiceClient())
			{
				var contactDto = _service.FindById(id);

				model.Id = contactDto.Id;
				model.Name = contactDto.Name;
				model.Email = contactDto.Email;
				model.Phone = contactDto.Phone;
			}

			return View(model);
		} 
		#endregion

		#region [ Edit(ContactViewModel model) ]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(ContactViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using (ContactServiceClient _service = new ContactServiceClient())
					{
						ContactDto contactDto = new ContactDto();
						contactDto.Id = model.Id;
						contactDto.Name = model.Name;
						contactDto.Email = model.Email;
						contactDto.Phone = model.Phone;

						_service.UpdateContact(contactDto);
					}

					return RedirectToAction("Index");
				}
			}
			catch (FaultException faultException)
			{
				ModelState.AddModelError("", faultException.Message);
			}

			return View(model);
		} 
		#endregion

		#region [ Delete(Guid id) ]
		public ActionResult Delete(Guid id)
		{
			var model = new ContactViewModel();
			using (ContactServiceClient _service = new ContactServiceClient())
			{
				var contactDto = _service.FindById(id);

				model.Id = contactDto.Id;
				model.Name = contactDto.Name;
				model.Email = contactDto.Email;
				model.Phone = contactDto.Phone;
			}

			return View(model);
		} 
		#endregion

		#region [ ConfirmDeleteContact(ContactViewModel model) ]
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult ConfirmDeleteContact(ContactViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using (ContactServiceClient _service = new ContactServiceClient())
					{
						ContactDto contactDto = new ContactDto();
						contactDto.Id = model.Id;
						contactDto.Name = model.Name;
						contactDto.Email = model.Email;
						contactDto.Phone = model.Phone;

						_service.DeleteContact(contactDto);
					}

					return RedirectToAction("Index");
				}
			}
			catch (FaultException faultException)
			{
				ModelState.AddModelError("", faultException.Message);
			}

			return View(model);
		} 
		#endregion
    }
}