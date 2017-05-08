using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AudioStreamApp.ViewModels;


namespace AudioStreamApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<char> _letters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();

        public ActionResult Index()
        {
            var vm = new MediaList {Letters = _letters};

            return View(vm);
        }
    }
}