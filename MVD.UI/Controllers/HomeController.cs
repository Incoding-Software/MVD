namespace MVD.UI.Controllers
{
    using System.Web.Mvc;
    using Incoding.CQRS;
    using Incoding.MvcContrib;

    public class HomeController:IncControllerBase
    {
        public HomeController(IDispatcher dispatcher)
                : base(dispatcher) { }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}