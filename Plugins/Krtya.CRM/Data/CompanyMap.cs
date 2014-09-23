using Krtya.CRM.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Krtya.CRM.Data
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            this.ToTable("CRMCompany");
            this.HasKey(x => x.Id);

            this.Ignore(c => c.ContactTypeEnum);
            
        }
    }
    
}
