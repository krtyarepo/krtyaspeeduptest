using Nop.Core;

namespace Krtya.CRM.Domain 
{
    public class CompanyPersonMapping : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Company identifier
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the Person identifier
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the Company
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// Gets or sets the Person
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
