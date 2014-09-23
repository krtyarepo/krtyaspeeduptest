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
    class KrtyaCRMPlugin: BasePlugin, IAdminMenuPlugin
    {
        #region Fields

        

        #endregion

        #region Ctor

        
        #endregion

        #region Methods


        public bool Authenticate()
        {
            return true;
        }

        public override void Install()
        {
            base.Install();
        }

        public override void Uninstall()
        {
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