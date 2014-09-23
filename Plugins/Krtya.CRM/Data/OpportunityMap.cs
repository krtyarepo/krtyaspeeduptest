using Krtya.CRM.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Krtya.CRM.Data
{
    public class OpportunityMap: EntityTypeConfiguration<Opportunity>
    {
        public OpportunityMap()
        {
            this.ToTable("CRMOpportunity");
            this.HasKey(x => x.Id);

            this.Ignore(o => o.BudgetTypeEnum);
            this.Ignore(o => o.OpportunityStageEnum);
        }
    }
}
