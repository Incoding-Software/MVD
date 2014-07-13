namespace MVD.UI.Controllers
{        
    using Incoding.MvcContrib.MVD;
    using MVD.Domain;

    public class DispatcherController : DispatcherControllerBase
    {
        public DispatcherController()
                : base(typeof(Bootstrapper).Assembly) { }
    }
}