using Nop.Core;
using System;
using System.Collections.Generic;

namespace Krtya.CRM.Domain
{
    public class Opportunity : BaseEntity
    {
        private ICollection<OpportunityHistory> _opportunityHistory;


        /// <summary>
        /// Gets of sets the title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets of sets the Budget
        /// </summary>
        public decimal Budget { get; set; }

        /// <summary>
        /// Gets or sets the Budget Type Id
        /// </summary>
        public int BudgetTypeId { get; set; }

        /// <summary>
        /// Estimated Deal Due Date
        /// </summary>
        public DateTime? EstimatestimatedDealDueDate { get; set; }

        /// <summary>
        /// Opportunity Stage 
        /// </summary>
        public int OpportunityStageId { get; set; }

        /// <summary>
        /// Gets or sets the Success Probability
        /// </summary>
        public int SuccessProbability { get; set; }

        /// <summary>
        /// Gets or sets the Deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the Created Date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the Updated Date
        /// </summary>
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the Budget Type Enum
        /// </summary>
        public BudgetTypeEnum BudgetTypeEnum
        {
            get
            {
                return (BudgetTypeEnum)this.BudgetTypeId;
            }
            set
            {
                this.BudgetTypeId = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets the Opportunity Stage Enum
        /// </summary>
        public OpportunityStageEnum OpportunityStageEnum
        {
            get
            {
                return (OpportunityStageEnum)this.OpportunityStageId;
            }
            set
            {
                this.OpportunityStageId = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets the Opportunity History
        /// </summary>
        public virtual ICollection<OpportunityHistory> OpportunityHistory
        {
            get { return _opportunityHistory ?? (_opportunityHistory = new List<OpportunityHistory>()); }
            protected set { _opportunityHistory = value; }
        }
 

    }
}
