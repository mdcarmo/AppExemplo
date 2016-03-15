using AppExample.Mvc.AuthenticationService;
using AppExample.Mvc.ViewModels;
using System;
using System.ServiceModel;
using System.Web.Mvc;

namespace AppExample.Mvc.Controllers
{
	public class AuthenticationController : BaseController
    {
		#region [ Login() ]
		public ActionResult Login()
		{
			return View();
		} 
		#endregion

		#region [ Login(LoginViewModel model, string returnUrl) ]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginViewModel model, string returnUrl)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using (AuthenticationServiceClient service = new AuthenticationServiceClient())
					{
						UserDto userDto = new UserDto
						{
							Email = model.Email,
							Password = model.Password
						};

						userDto = service.AuthenticateUser(userDto);

						SaveUserDataInCookie(userDto.Name, userDto.Email);

						return Redirect(returnUrl ?? Url.Action("Index", "Home"));
					}
				}
			}
			catch (FaultException faultException)
			{
				ModelState.AddModelError("", faultException.Message);
			}
			return View(model);
		} 
		#endregion

		#region [ LogOut() ]
		[Authorize]
		public ActionResult LogOut()
		{
			LogOutCookie();

			return RedirectToAction("Login");
		} 
		#endregion

		#region [ RetrivePassword() ]
		public ActionResult RetrivePassword()
		{
			return View(new RetrivePasswordViewModel());
		} 
		#endregion

		#region [ RetrivePassword(RetrivePasswordViewModel model) ]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult RetrivePassword(RetrivePasswordViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					using (AuthenticationServiceClient service = new AuthenticationServiceClient())
					{
						model.PasswordRecovered = service.RetrivePassword(model.Email);
					}
				}
			}
			catch (FaultException faultException)
			{
				ModelState.AddModelError("", faultException.Message);
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "Ocorreu um erro com o serviço, tente novamente mais tarde!");
			}

			return View(model);
		} 
		#endregion
    }
}