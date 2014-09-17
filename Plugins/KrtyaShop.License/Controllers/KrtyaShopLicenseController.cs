using KrtyaShop.License.Domain;
using KrtyaShop.License.Models;
using KrtyaShop.License.Services;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Kendoui;
using System;
using System.Web.Mvc;
using System.Linq;

namespace KrtyaShop.License.Controllers
{
    [AdminAuthorize]
    public class KrtyaShopLicenseController : BasePluginController
    {
        #region Fields

        private readonly ILicenseServices _licenseServices;

        #endregion

        #region Ctor

        public KrtyaShopLicenseController(ILicenseServices licenseServices)
        {
            _licenseServices = licenseServices;
        }

        #endregion

        #region Utilities

        [NonAction]
        protected virtual void PrepareLicenseRecordModel(LicenseRecordModel model, LicenseRecord licenseRecord)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Id = licenseRecord.Id;
            model.CustomerId = licenseRecord.CustomerId;
            model.ProductId = licenseRecord.ProductId;
            model.LicenseKey = licenseRecord.LicenseKey;
            model.LicenseTypeId = licenseRecord.LicenseTypeId;
            model.OrderId = licenseRecord.OrderId;
            model.SoftwareProductTypeId = licenseRecord.SoftwareProductTypeId;
            model.ProgrammingLanguages = licenseRecord.ProgrammingLanguages;
            model.Framework = licenseRecord.Framework;
            model.ExpiryDateUTC = licenseRecord.ExpiryDateUTC;
            model.LastRenewalDateUTC = licenseRecord.LastRenewalDateUTC;
            model.UpdatedDateUTC = licenseRecord.UpdatedDateUTC;
            model.CreatedDateUTC = licenseRecord.CreatedDateUTC;
       
        }

        #endregion


        #region Methods

        public ActionResult Configure()
        {
            return View("~/Plugins/KrtyaShop.License/Views/KrtyaShopLicense/Configure.cshtml");
        }

        [HttpPost]
        public ActionResult LicenseRecordList(DataSourceRequest command)
        {
            var licenseRecords = _licenseServices.GetAllLicenseRecords(command.Page - 1, command.PageSize);
            var gridModel = new DataSourceResult
            {
                Data = licenseRecords.Select(x =>
                {
                    var m = new LicenseRecordModel();
                    PrepareLicenseRecordModel(m, x);
                    return m;
                }),
                Total = licenseRecords.TotalCount,
            };
            return Json(gridModel);
        }

        #endregion
    }
}
