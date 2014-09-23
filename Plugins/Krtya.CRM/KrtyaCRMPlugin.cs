using Krtya.CRM.Data;
using Nop.Core.Plugins;
using Nop.Web.Framework.Menu;
using Nop.Web.Framework.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krtya.CRM
{
    public class KrtyaCRMPlugin : BasePlugin, IAdminMenuPlugin
    {
      #region Fields

        private readonly KrtyaCRMObjectContext _objectContext;

        #endregion

        #region Ctor

        public KrtyaCRMPlugin(KrtyaCRMObjectContext objectContext)
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
            SiteMapNode node = new SiteMapNode { Visible = true, Title = "Krtya CRM", Url = "/Plugins/KrtyaShopLicense/Configure" };
            return node;
        }
    }
}