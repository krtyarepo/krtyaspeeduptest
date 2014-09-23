using Krtya.CRM.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Krtya.CRM.Data
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            this.ToTable("CRMPerson");
            this.HasKey(x => x.Id);

        }
    }
    
}
