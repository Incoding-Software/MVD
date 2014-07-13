using System;

[assembly: WebActivator.PreApplicationStartMethod(
    typeof(MVD.UI.App_Start.IncodingStart), "PreStart")]

namespace MVD.UI.App_Start {
    using MVD.Domain;
    using MVD.UI.Controllers;

    public static class IncodingStart {
        public static void PreStart() {
            Bootstrapper.Start();
            new DispatcherController(); // init routes
        }
    }
}