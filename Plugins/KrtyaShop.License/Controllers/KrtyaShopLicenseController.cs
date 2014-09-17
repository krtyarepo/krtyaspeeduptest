using Nop.Web.Framework.Controllers;
using System.Web.Mvc;

namespace KrtyaShop.License.Controllers
{
    [AdminAuthorize]
    public class KrtyaShopLicenseController : BasePluginController
    {
        public ActionResult Configure()
        {
            return View("~/Plugins/KrtyaShop.License/Views/KrtyaShopLicense/Configure.cshtml");
        }
    }
}
