using KrtyaShop.License.Data;
using Nop.Core.Plugins;
using Nop.Services.Common;
using Nop.Web.Framework.Menu;
using Nop.Web.Framework.Web;

namespace KrtyaShop.License
{
    public class LicensePlugin : BasePlugin, IAdminMenuPlugin
    {
        #region Fields

        private readonly LicenseObjectContext _objectContext;

        #endregion

        #region Ctor

        public LicensePlugin(LicenseObjectContext objectContext)
        {
            _objectContext = objectContext;
        }

        #endregion

        #region Methods


        public bool Authenticate()
        {
            return true;
        }

        public override void Install()
        {
            _objectContext.Install();

            base.Install();
        }

        public override void Uninstall()
        {
            _objectContext.Uninstall();

            base.Uninstall();
        }

        #endregion


        public Nop.Web.Framework.Menu.SiteMapNode BuildMenuItem()
        {
            SiteMapNode node = new SiteMapNode { Visible = true, Title = "Krtya Licenses", Url = "/Plugins/KrtyaShopLicense/Configure" };
            return node;
        }
    }
}
