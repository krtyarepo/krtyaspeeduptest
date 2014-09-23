using Krtya.CRM.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Krtya.CRM.Data
{
    public class OpportunityPersonMappingMap : EntityTypeConfiguration<OpportunityPersonMapping>
    {
        public OpportunityPersonMappingMap()
        {
            this.ToTable("CRMOpportunityPersonMapping");
            this.HasKey(x => x.Id);

            this.HasRequired(o => o.Opportunity)
             .WithMany()
             .HasForeignKey(o => o.OpportunityId);

            this.HasRequired(o => o.Person)
              .WithMany()
              .HasForeignKey(o => o.PersonId);
        }
    }
}
