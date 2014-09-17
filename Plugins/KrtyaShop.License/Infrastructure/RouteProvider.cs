using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace KrtyaShop.License.Infrastructure
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Plugin.KrtyaShop.License.Configure",
                 "Plugins/KrtyaShopLicense/Configure",
                 new { controller = "KrtyaShopLicense", action = "Configure" },
                 new[] { "KrtyaShop.License.Controllers" }
            );

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
