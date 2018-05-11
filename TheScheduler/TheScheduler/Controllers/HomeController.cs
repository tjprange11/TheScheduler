using System.Web.Mvc;

namespace TheScheduler.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            bool role = User.IsInRole("Owner");
            if (role)
            {
                return RedirectToAction("Home", "Owners");
            }
            role = User.IsInRole("Consumer");
            if (role)
            {
                return RedirectToAction("Home", "Consumers");
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}