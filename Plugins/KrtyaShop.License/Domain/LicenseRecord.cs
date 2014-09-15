using Nop.Core;
using System;

namespace KrtyaShop.License.Domain
{
    public class LicenseRecord : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Customer Id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the Product Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the License Key
        /// </summary>
        public string LicenseKey { get; set; }

        /// <summary>
        /// Gets or sets the License Type Id
        /// </summary>
        public int LicenseTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Order Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Software Product Type Id
        /// </summary>
        public int SoftwareProductTypeId { get; set; }

        /// <summary>
        /// Programming Languages
        /// </summary>
        public string ProgrammingLanguages { get; set; }

        /// <summary>
        /// Framework
        /// </summary>
        public string Framework { get; set; }

        /// <summary>
        /// Expriy Date
        /// </summary>
        public DateTime? ExpiryDateUTC { get; set; }

        /// <summary>
        /// Last Renewal Date
        /// </summary>
        public DateTime? LastRenewalDateUTC { get; set; }

        /// <summary>
        /// Created Date UTC
        /// </summary>
        public DateTime CreatedDateUTC { get; set; }

        /// <summary>
        /// Updated Date UTC
        /// </summary>
        public DateTime UpdatedDateUTC { get; set; }


        /// <summary>
        /// Gets or sets the License Type
        /// </summary>
        public LicenseTypeEnum LicenseTypeEnum
        {
            get
            {
                return (LicenseTypeEnum)this.LicenseTypeId;
            }
            set
            {
                this.LicenseTypeId = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets the Software Product Type Id
        /// </summary>
        public SoftwareProductType SoftwareProductType
        {
            get
            {
                return (SoftwareProductType)this.SoftwareProductTypeId;
            }
            set
            {
                this.SoftwareProductTypeId = (int)value;
            }
        }
    }
}
