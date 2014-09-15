using KrtyaShop.License.Domain;
using System.Data.Entity.ModelConfiguration;

namespace KrtyaShop.License.Data
{
    public class LicenseRecordMap : EntityTypeConfiguration<LicenseRecord>
    {
        public LicenseRecordMap()
        {
            this.ToTable("LicenseRecord");
            this.HasKey(x => x.Id);

            this.Ignore(l => l.LicenseTypeEnum);
            this.Ignore(l => l.SoftwareProductType);
        }
    }
}
