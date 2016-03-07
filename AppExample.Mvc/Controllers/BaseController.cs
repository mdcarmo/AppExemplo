using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppExample.Mvc.Controllers
{
    public class BaseController : Controller
    {
		protected void SaveUserDataInCookie(string nameUser, string emailUser)
		{
			//Nessa app vou guardar o usuário em cookie
			FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, nameUser, DateTime.Now, DateTime.Now.AddHours(24), true, emailUser);
			// Criptografo os dados
			string ticketCript = FormsAuthentication.Encrypt(ticket);

			// Crio o cookie.
			Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, ticketCript));
		}
		protected string GetEmailUserOnline()
		{
			FormsIdentity id = (FormsIdentity)User.Identity;
			FormsAuthenticationTicket ticket = id.Ticket;

			return ticket.UserData;
		}

		protected void LogOutCookie()
		{
			FormsAuthentication.SignOut();
		}
    }
}