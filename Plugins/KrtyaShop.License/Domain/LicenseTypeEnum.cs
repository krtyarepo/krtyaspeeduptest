namespace KrtyaShop.License.Domain
{
    /// <summary>
    /// Represent License Type Enum
    /// </summary>
    public enum LicenseTypeEnum : int
    {
        /// <summary>
        ///  License type for single installation
        /// </summary>
        Individual = 10,

        /// <summary>
        ///  (Original Equipment Manufacturers): License type for software that is already installed in the hardware.
        /// </summary>
        OEM = 20,

        /// <summary>
        /// License Type for a specific user.
        /// </summary>
        NamedUserLicense = 30,

        /// <summary>
        /// License Type supporting multiple users.
        /// </summary>
        Volume = 40,

        /// <summary>
        /// (CAL): License type that gives a user the rights to access the services of the server.
        /// </summary>
        ClientAccessLicense = 50,

        /// <summary>
        /// License Type for trial versions of software.
        /// </summary>
        TrialLicense = 60,

        /// <summary>
        /// Enterprise (Perpetual): License Type that does not require renewal and is for life long.
        /// </summary>
        Enterprise = 70,

        /// <summary>
        /// License Type for software that can be accessed by a specific number of users at a time.
        /// </summary>
        ConcurrentLicense = 80,

        /// <summary>
        /// License Type for freeware software.
        /// </summary>
        FreeLicense = 90,

        /// <summary>
        /// License Type that requires renewal for every specific period.
        /// </summary>
        EnterpriseSubscription = 100,

        /// <summary>
        /// License Type for workstations with specific configurations.
        /// </summary>
        NodeLocked = 110
    }
}
