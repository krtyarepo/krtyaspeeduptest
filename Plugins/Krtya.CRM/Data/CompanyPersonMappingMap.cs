using Krtya.CRM.Domain;
using System.Data.Entity.ModelConfiguration;


namespace Krtya.CRM.Data
{
    public class CompanyPersonMappingMap : EntityTypeConfiguration<CompanyPersonMapping>
    {
        public CompanyPersonMappingMap()
        {
            this.ToTable("CRMCompanyPersonMapping");
            this.HasKey(x => x.Id);

            this.HasRequired(cp => cp.Company)
              .WithMany()
              .HasForeignKey(cp=>cp.CompanyId);

            this.HasRequired(cp => cp.Person)
              .WithMany()
              .HasForeignKey(cp => cp.PersonId);
        }
    }
}

