using Autofac;
using Autofac.Core;
using KrtyaShop.License.Data;
using KrtyaShop.License.Domain;
using KrtyaShop.License.Services;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Web.Framework.Mvc;

namespace KrtyaShop.License.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<LicenseServices>().As<ILicenseServices>().InstancePerLifetimeScope();

            //data context
            this.RegisterPluginDataContext<LicenseObjectContext>(builder, "nop_object_context_krtya_license");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<LicenseRecord>>()
                .As<IRepository<LicenseRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_krtya_license"))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<LicenseValidationCallLog>>()
                .As<IRepository<LicenseValidationCallLog>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_krtya_license"))
                .InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
