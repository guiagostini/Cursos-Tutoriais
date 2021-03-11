using System.Web.Mvc;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Sobre()
        {
            return View();
        }
    }
}
