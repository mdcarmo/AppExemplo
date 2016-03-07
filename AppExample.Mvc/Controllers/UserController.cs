using AppExample.Mvc.UserService;
using AppExample.Mvc.ViewModels;
using System;
using System.ServiceModel;
using System.Web.Mvc;

namespace AppExample.Mvc.Controllers
{
    public class UserController : BaseController
    {
		#region [ Create() ]
		public ActionResult Create()
		{
			return View();
		} 
		#endregion

		#region [ Create(UserViewModel model) ]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(UserViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using (UserServiceClient _service = new UserServiceClient())
					{
						UserDto usuarioDto = new UserDto
						{
							Name = model.Name,
							Email = model.Email,
							Password = model.Password
						};

						_service.AddNewUser(usuarioDto);
					}

					return RedirectToAction("Login", "Authentication");
				}
			}
			catch (FaultException faultException)
			{
				ModelState.AddModelError("", faultException.Message);
			}
			catch (Exception)
			{
				//log
				ModelState.AddModelError("", "Ocorreu um erro com o serviço, tente novamente mais tarde!");
			}

			return View(model);
		} 
		#endregion

		#region [ AlterPassword() ]
		[Authorize]
		public ActionResult AlterPassword()
		{
			return View();
		} 
		#endregion

		#region [ ConfirmAlterPassword(AlterPasswordViewModel model) ]
		[HttpPost, ActionName("AlterPassword")]
		[ValidateAntiForgeryToken]
		public ActionResult ConfirmAlterPassword(AlterPasswordViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using (UserServiceClient _service = new UserServiceClient())
					{
						ChangePasswordDto changePasswordDto = new ChangePasswordDto
						{
							Email = GetEmailUserOnline(),
							Password = model.CurrentPassword,
							PasswordNew = model.PasswordNew,
							ConfirmPasswordNew = model.ConfirmPasswordNew
						};

						_service.ChangePassword(changePasswordDto);

					}

					LogOutCookie();

					return RedirectToAction("Login", "Autenthication");
				}
			}
			catch (FaultException faultException)
			{
				ModelState.AddModelError("", faultException.Message);
			}
			catch (Exception)
			{
				//log
				ModelState.AddModelError("", "Ocorreu um erro com o serviço, tente novamente mais tarde!");
			}

			return View(model);
		} 
		#endregion
    }
}