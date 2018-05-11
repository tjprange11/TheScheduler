using System.Web.Mvc;
using TheScheduler.Models;

namespace TheScheduler.Controllers
{
    public class OwnersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Owners
        public ActionResult Home()
        {
            return View();
        }

        
        
    }
}
