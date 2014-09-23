namespace Krtya.CRM.Domain
{
    public enum OpportunityStageEnum : int
    {
        /// <summary>
        /// Initial Contact
        /// </summary>
        InitialContact = 10,

        /// <summary>
        /// Proposal
        /// </summary>
        Proposal = 20,

        /// <summary>
        /// Negotiations
        /// </summary>
        Negotiations = 30,

        /// <summary>
        /// Closure / Transaction
        /// </summary>
        ClosureOrTransaction = 40,

        /// <summary>
        /// Unsucessfully Closed
        /// </summary>
        UnsuccessfullyClosed = 50
    }
}
