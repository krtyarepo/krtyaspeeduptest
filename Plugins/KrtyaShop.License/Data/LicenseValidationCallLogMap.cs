using KrtyaShop.License.Domain;
using System.Data.Entity.ModelConfiguration;

namespace KrtyaShop.License.Data
{
    public class LicenseValidationCallLogMap : EntityTypeConfiguration<LicenseValidationCallLog>
    {
        public LicenseValidationCallLogMap()
        {
            this.ToTable("LicenseValidationCallLog");
            this.HasKey(x => x.Id);
        }
    }
}
