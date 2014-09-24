using Nop.Web.Framework.Controllers;
using System.Web.Mvc;

namespace Krtya.CRM.Controllers
{
    [AdminAuthorize]
    public class CRMController : BasePluginController
    {
        public ActionResult Dashboard()
        {
            return View("~/Plugins/Krtya.CRM/Views/CRM/Dashboard.cshtml");
        }

        #region Company

        public ActionResult Company()
        {
            return View("~/Plugins/Krtya.CRM/Views/CRM/Company/Company.cshtml");
        }

        #endregion
    }
}
