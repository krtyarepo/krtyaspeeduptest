using Krtya.CRM.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Krtya.CRM.Data
{
    public class OpportunityHistoryMap : EntityTypeConfiguration<OpportunityHistory>
    {
        public OpportunityHistoryMap()
        {
            this.ToTable("CRMOpportunityHistory");
            this.HasKey(x => x.Id);

            this.HasRequired(o => o.Opportunity)
               .WithMany(o => o.OpportunityHistory)
               .HasForeignKey(o=>o.OpportunityId);

            this.Ignore(op => op.OpportunityEventTypeEnum);
        }
    }
}
