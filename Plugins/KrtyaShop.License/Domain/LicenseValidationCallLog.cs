using Nop.Core;
using System;

namespace KrtyaShop.License.Domain
{
    public class LicenseValidationCallLog : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Cusomer Id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the Prouct Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the IP address
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the Request Parameters
        /// </summary>
        public string RequestParameters { get; set; }

        /// <summary>
        /// Response Code
        /// </summary>
        public int ResponseCode { get; set; }

        /// <summary>
        /// Created Date UTC
        /// </summary>
        public DateTime CreatedDateUTC { get; set; }
    }
}
