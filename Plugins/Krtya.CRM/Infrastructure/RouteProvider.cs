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

            routes.MapRoute("Plugin.Krtya.CRM.Company.Create",
                 "Plugins/KrtyaCRM/CreateCompany",
                 new { controller = "CRM", action = "CreateCompany" },
                 new[] { "Krtya.CRM.Controllers" }
            );

            routes.MapRoute("Plugin.Krtya.CRM.Company.Details",
                 "Plugins/KrtyaCRM/CompanyDetail/{companyId}",
                 new { controller = "CRM", action = "CompanyDetail" },
                 new { companyId = @"\d+" },
                 new[] { "Krtya.CRM.Controllers" }
            );

            routes.MapRoute("Plugin.Krtya.CRM.Company.Edit",
                 "Plugins/KrtyaCRM/CompanyEdit/{companyId}",
                 new { controller = "CRM", action = "CompanyEdit" },
                 new { companyId = @"\d+" },
                 new[] { "Krtya.CRM.Controllers" }
            );


            routes.MapRoute("Plugin.Krtya.CRM.Company.LinkPerson",
                   "Plugins/KrtyaCRM/LinkPerson",
                 new { controller = "CRM", action = "LinkPerson" },
                 new[] { "Krtya.CRM.Controllers" }
              );

            routes.MapRoute("Plugin.Krtya.CRM.Company.UnLinkPerson",
                   "Plugins/KrtyaCRM/UnLinkPerson",
                 new { controller = "CRM", action = "UnLinkPerson" },
                 new[] { "Krtya.CRM.Controllers" }
              );


            #endregion

            #region Person

            routes.MapRoute("Plugin.Krtya.CRM.Person",
                 "Plugins/KrtyaCRM/Person",
                 new { controller = "CRM", action = "Person" },
                 new[] { "Krtya.CRM.Controllers" }
            );

            routes.MapRoute("Plugin.Krtya.CRM.Person.Create",
                 "Plugins/KrtyaCRM/CreatePerson",
                 new { controller = "CRM", action = "CreatePerson" },
                 new[] { "Krtya.CRM.Controllers" }
            );

            routes.MapRoute("Plugin.Krtya.CRM.Person.Details",
                 "Plugins/KrtyaCRM/PersonDetail/{personId}",
                 new { controller = "CRM", action = "PersonDetail" },
                 new { personId = @"\d+" },
                 new[] { "Krtya.CRM.Controllers" }
            );

            routes.MapRoute("Plugin.Krtya.CRM.Person.Edit",
                 "Plugins/KrtyaCRM/PersonEdit/{personId}",
                 new { controller = "CRM", action = "PersonEdit" },
                 new { personId = @"\d+" },
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
