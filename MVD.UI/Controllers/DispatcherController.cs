namespace MVD.UI.Controllers
{
    #region << Using >>

    using System;
    using System.IO;
    using Incoding.MvcContrib.MVD;

    #endregion

    public class DispatcherController : DispatcherControllerBase
    {
        #region Constructors

        public DispatcherController()
                : base(new[] { Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin", "MVD.Domain.dll") }) { }

        #endregion
    }
}