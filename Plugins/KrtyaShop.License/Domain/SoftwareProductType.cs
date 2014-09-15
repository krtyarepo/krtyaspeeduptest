namespace KrtyaShop.License.Domain
{
    public enum SoftwareProductType : int
    {
        /// <summary>
        /// Websites or WebApplication
        /// </summary>
        WebApplication = 10,

        /// <summary>
        /// Windows or Desktop Application
        /// </summary>
        Desktop = 20,

        /// <summary>
        /// iOS App
        /// </summary>
        iOSApp = 30,

        /// <summary>
        /// Android App
        /// </summary>
        AndroidApp = 40,

        /// <summary>
        /// WebServices
        /// </summary>
        WebServices = 50
    }
}
