
using KrtyaShop.License.Domain;
namespace KrtyaShop.License.Services
{
    public interface ILicenseServices
    {
        #region License Record

        /// <summary>
        /// Insert License Record
        /// </summary>
        /// <param name="licenseRecord">License Record</param>
        void InsertLicenseRecord(LicenseRecord licenseRecord);
        

        /// <summary>
        /// Update License Record
        /// </summary>
        /// <param name="licenseRecord">License Record</param>
        void UpdateLicenseRecord(LicenseRecord licenseRecord);
        

        #endregion

        #region License Validation Call Log

        /// <summary>
        /// Insert License Validation Call Log
        /// </summary>
        /// <param name="licenseValidationCallLog">LicenseValidationCallLog</param>
        void InsertLicenseValidationCallLog(LicenseValidationCallLog licenseValidationCallLog);
        

        #endregion 
    }
}
