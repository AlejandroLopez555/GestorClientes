using System.Web.Mvc;

namespace SistemaGestionClientes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}