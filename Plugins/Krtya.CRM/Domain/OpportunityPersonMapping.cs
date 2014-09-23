using Nop.Core;
namespace Krtya.CRM.Domain
{
    public  class OpportunityPersonMapping : BaseEntity 
    {
        /// <summary>
        /// Gets or sets the Opportunity Id
        /// </summary>
        public int OpportunityId { get; set; }

        /// <summary>
        /// Gets or sets the Person Id
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the Opportunity 
        /// </summary>
        public virtual Opportunity Opportunity { get; set; }

        /// <summary>
        /// Gets or sets the Person
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
