namespace MVD.UI.Controllers
{
    #region << Using >>

    using System.Web.Mvc;
    using Incoding.MvcContrib;

    #endregion

    public class HomeController : IncControllerBase
    {
        #region Http action

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}