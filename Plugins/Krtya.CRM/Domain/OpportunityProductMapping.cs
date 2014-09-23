using Nop.Core;

namespace Krtya.CRM.Domain
{
    public class OpportunityProductMapping : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Opportunity Id
        /// </summary>
        public int OpportunityId { get; set; }

        /// <summary>
        /// Gets or sets the Product Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Opportunity 
        /// </summary>
        public virtual Opportunity Opportunity { get; set; }


        // We can not get Product object because Product is from different object context
    }
}
