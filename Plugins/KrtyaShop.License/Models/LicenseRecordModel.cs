using Nop.Web.Framework.Mvc;
using System;
namespace KrtyaShop.License.Models
{
    public class LicenseRecordModel : BaseNopEntityModel
    {
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public string LicenseKey { get; set; }

        public int LicenseTypeId { get; set; }

        public int OrderId { get; set; }

        public int SoftwareProductTypeId { get; set; }

        public string ProgrammingLanguages { get; set; }

        public string Framework { get; set; }

        public DateTime? ExpiryDateUTC { get; set; }

        public DateTime? LastRenewalDateUTC { get; set; }

        public DateTime CreatedDateUTC { get; set; }

        public DateTime UpdatedDateUTC { get; set; }
    }
}
