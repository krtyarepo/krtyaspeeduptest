using KrtyaShop.License.Data;
using Nop.Core.Plugins;
using Nop.Services.Common;

namespace KrtyaShop.License
{
    public class LicensePlugin : BasePlugin
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
    }
}
