using Krtya.CRM.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Krtya.CRM.Data
{
    public class OpportunityProductMappingMap : EntityTypeConfiguration<OpportunityProductMapping>
    {
        public OpportunityProductMappingMap()
        {
            this.ToTable("CRMOpportunityProductMapping");
            this.HasKey(x => x.Id);

            this.HasRequired(o => o.Opportunity)
             .WithMany()
             .HasForeignKey(o => o.OpportunityId);

        }
    }
}
