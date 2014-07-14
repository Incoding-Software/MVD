namespace MVD.UI
{
    #region << Using >>

    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using FluentValidation.Mvc;
    using Incoding.MvcContrib;
    using MVD.Domain;
    using MVD.UI.Controllers;

    #endregion

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);                       
        }

        protected void Application_Error()
        {
            var er = Server.GetLastError();
            Server.ClearError();
        }
    }
}