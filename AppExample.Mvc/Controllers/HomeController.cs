using System.Web.Mvc;

namespace AppExample.Mvc.Controllers
{
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}