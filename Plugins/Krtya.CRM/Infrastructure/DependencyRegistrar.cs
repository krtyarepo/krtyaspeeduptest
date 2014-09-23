using Autofac;
using Autofac.Core;
using Krtya.CRM.Data;
using Krtya.CRM.Domain;
using Krtya.CRM.Services;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Web.Framework.Mvc;

namespace Krtya.CRM.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<OpportunityServices>().As<IOpportunityServices>().InstancePerLifetimeScope();
            builder.RegisterType<PersonServices>().As<IPersonServices>().InstancePerLifetimeScope();
            builder.RegisterType<CompanyServices>().As<ICompanyServices>().InstancePerLifetimeScope();

            //data context
            this.RegisterPluginDataContext<KrtyaCRMObjectContext>(builder, "nop_object_context_krtya_crm");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<Company>>()
                .As<IRepository<Company>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_krtya_crm"))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<Person>>()
                .As<IRepository<Person>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_krtya_crm"))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<Opportunity>>()
                .As<IRepository<Opportunity>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_krtya_crm"))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<OpportunityHistory>>()
                .As<IRepository<OpportunityHistory>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_krtya_crm"))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<OpportunityPersonMapping>>()
                .As<IRepository<OpportunityPersonMapping>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_krtya_crm"))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<OpportunityProductMapping>>()
                .As<IRepository<OpportunityProductMapping>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_krtya_crm"))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<CompanyPersonMapping>>()
                .As<IRepository<CompanyPersonMapping>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_krtya_crm"))
                .InstancePerLifetimeScope();

        }

        public int Order
        {
            get { return 1; }
        }
    }
}
