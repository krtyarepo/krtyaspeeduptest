using KrtyaShop.License.Domain;
using Nop.Core.Data;
using System;

namespace KrtyaShop.License.Services
{
    public class LicenseServices : ILicenseServices
    {
        #region Fields

        private readonly IRepository<LicenseRecord> _licenseRecordRepository;
        private readonly IRepository<LicenseValidationCallLog> _licenseValidationCallLog;

        #endregion

        #region Ctor

        public LicenseServices(IRepository<LicenseRecord> licenseRecordRepository, IRepository<LicenseValidationCallLog> licenseValidationCallLog)
        {
            this._licenseRecordRepository = licenseRecordRepository;
            this._licenseValidationCallLog = licenseValidationCallLog;
        }

        #endregion

        #region Methods

        #region License Record

        /// <summary>
        /// Insert License Record
        /// </summary>
        /// <param name="licenseRecord">License Record</param>
        public virtual void InsertLicenseRecord(LicenseRecord licenseRecord)
        {
            if (licenseRecord == null)
                throw new ArgumentNullException("licenseRecord");

            _licenseRecordRepository.Insert(licenseRecord);
        }

        /// <summary>
        /// Update License Record
        /// </summary>
        /// <param name="licenseRecord">License Record</param>
        public virtual void UpdateLicenseRecord(LicenseRecord licenseRecord)
        {
            if (licenseRecord == null)
                throw new ArgumentNullException("licenseRecord");

            _licenseRecordRepository.Update(licenseRecord);
        }

        #endregion 

        #region License Validation Call Log

        /// <summary>
        /// Insert License Validation Call Log
        /// </summary>
        /// <param name="licenseValidationCallLog">LicenseValidationCallLog</param>
        public virtual void InsertLicenseValidationCallLog(LicenseValidationCallLog licenseValidationCallLog)
        {
            if (licenseValidationCallLog == null)
                throw new ArgumentNullException("licenseValidationCallLog");

            _licenseValidationCallLog.Insert(licenseValidationCallLog);
        }
            

        #endregion 

        #endregion

    }
}
