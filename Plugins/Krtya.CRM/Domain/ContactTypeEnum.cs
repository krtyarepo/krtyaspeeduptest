namespace Krtya.CRM.Domain
{
    public enum ContactTypeEnum : int
    {
        /// <summary>
        /// None, Not specified
        /// </summary>
        None = 10,

        /// <summary>
        /// Client
        /// </summary>
        Client = 20,

        /// <summary>
        /// Supplier
        /// </summary>
        Supplier = 30,

        /// <summary>
        /// Partner
        /// </summary>
        Partner = 40,

        /// <summary>
        /// Competitor
        /// </summary>
        Competitor = 50
    }
}
