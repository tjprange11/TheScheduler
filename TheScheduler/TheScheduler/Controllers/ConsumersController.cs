using System.Linq;
using System.Web.Mvc;
using TheScheduler.Models;

namespace TheScheduler.Controllers
{
    public class ConsumersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consumers
        public ActionResult Index()
        {
            return View(db.Consumers.ToList());
        }

        // GET: Consumers/Details/5
        
    }
}
