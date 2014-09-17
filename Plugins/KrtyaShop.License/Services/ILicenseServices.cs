
using KrtyaShop.License.Domain;
using Nop.Core;
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
        

        /// <summary>
        /// GetAllLicenseRecords
        /// </summary>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>License Records</returns>
        IPagedList<LicenseRecord> GetAllLicenseRecords(int pageIndex, int pageSize);
        

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
