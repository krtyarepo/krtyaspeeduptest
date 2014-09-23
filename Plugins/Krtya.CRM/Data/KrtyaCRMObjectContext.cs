using Nop.Core;
using Nop.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Krtya.CRM.Data
{
    public class KrtyaCRMObjectContext : DbContext, IDbContext
    {
        public KrtyaCRMObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new PersonMap());

            modelBuilder.Configurations.Add(new OpportunityMap());
            modelBuilder.Configurations.Add(new OpportunityHistoryMap());

            modelBuilder.Configurations.Add(new CompanyPersonMappingMap());
            modelBuilder.Configurations.Add(new OpportunityPersonMappingMap());
            modelBuilder.Configurations.Add(new OpportunityProductMappingMap());

            base.OnModelCreating(modelBuilder);
        }

        public string CreateDatabaseInstallationScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        public void Install()
        {
            //It's required to set initializer to null (for SQL Server Compact).
            //otherwise, you'll get something like "The model backing the 'your context name' context has changed since the database was created. Consider using Code First Migrations to update the database"
            Database.SetInitializer<KrtyaCRMObjectContext>(null);

            Database.ExecuteSqlCommand(CreateDatabaseInstallationScript());
            SaveChanges();
        }

        public void Uninstall()
        {

            var dbScript = "DROP TABLE CRMOpportunityProductMapping; DROP TABLE CRMOpportunityPersonMapping; DROP TABLE CRMOpportunityHistory;DROP TABLE CRMOpportunity; DROP TABLE CRMCompanyPersonMapping; DROP TABLE CRMPerson; DROP TABLE CRMCompany; ";
            Database.ExecuteSqlCommand(dbScript);
            SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public System.Collections.Generic.IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            throw new System.NotImplementedException();
        }

        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
