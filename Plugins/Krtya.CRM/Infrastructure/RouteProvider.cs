using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace Krtya.CRM.Infrastructure
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Plugin.Krtya.CRM.Dashboard",
                 "Plugins/KrtyaCRM/Dashboard",
                 new { controller = "CRM", action = "Dashboard" },
                 new[] { "Krtya.CRM.Controllers" }
            );

            #region Company

            routes.MapRoute("Plugin.Krtya.CRM.Company",
                 "Plugins/KrtyaCRM/Company",
                 new { controller = "CRM", action = "Company" },
                 new[] { "Krtya.CRM.Controllers" }
            );

            #endregion

        }
        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
