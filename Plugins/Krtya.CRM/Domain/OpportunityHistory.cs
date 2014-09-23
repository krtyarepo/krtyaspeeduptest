using Nop.Core;
using System;
namespace Krtya.CRM.Domain
{
    public class OpportunityHistory : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Opportunity identifier
        /// </summary>
        public int OpportunityId { get; set; }

        /// <summary>
        /// Gets or sets the Opportunity Event Type Id
        /// </summary>
        public int OpportunityEventTypeId { get; set; }

        /// <summary>
        /// Gets or sets the History Date
        /// </summary>
        public DateTime? HistoryDate { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Customer Id
        /// </summary>
        public int CusotmerId { get; set; }

        /// <summary>
        /// Gets or set the Deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or Sets the Created Date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or set the Opportunity
        /// </summary>
        public virtual Opportunity Opportunity { get; set; }

        /// <summary>
        /// Gets or sets the Opportunity Event Type Enum
        /// </summary>
        public OpportunityEventTypeEnum OpportunityEventTypeEnum
        {
            get
            {
                return (OpportunityEventTypeEnum)this.OpportunityEventTypeId;
            }
            set
            {
                this.OpportunityEventTypeId = (int)value;
            }
        }
    }
}
