using Krtya.CRM.Models;
using Krtya.CRM.Services;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Kendoui;
using System.Web.Mvc;
using System.Linq;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Krtya.CRM.Domain;
using System;

namespace Krtya.CRM.Controllers
{
    //TODO Add try catch to every method
    [AdminAuthorize]
    public class CRMController : BasePluginController
    {
        #region Fields

        private readonly ICompanyServices _companyServices;
        private readonly ICountryService _countryService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Ctor

        public CRMController(ICompanyServices companyServices, ICountryService countryService,
            IStateProvinceService stateProvinceService, ILocalizationService localizationService)
        {
            _companyServices = companyServices;
            _countryService = countryService;
            _stateProvinceService = stateProvinceService;
            _localizationService = localizationService;
        }

        #endregion

        #region Utilities

        [NonAction]
        protected virtual void PrepareCompanyModel(CompanyModel model, Company company)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Id = company.Id;
            model.CompanyName = company.CompanyName;
            model.Email = company.Email;
            model.Description = company.Description;
            model.Description = company.Description;
            model.Address1 = company.Address1;
            model.Address2 = company.Address2;
            model.ZipPostalCode = company.ZipPostalCode;
            model.City = company.City;
            model.CountryId = company.CountryId;
            if (company.CountryId.HasValue && company.CountryId.Value > 0)
            {
                model.CountryName = _countryService.GetCountryById(company.CountryId.Value).Name.ToString();
            }
            model.StateProvinceId = company.StateProvinceId;

            if (company.StateProvinceId.HasValue && company.StateProvinceId.Value > 0)
            {
                model.StateProvinceName = _stateProvinceService.GetStateProvinceById(company.StateProvinceId.Value).Name.ToString();
            }
            model.PhoneNumber = company.PhoneNumber;
            model.FaxNumber = company.FaxNumber;
        }

        #endregion


        public ActionResult Dashboard()
        {
            return View("~/Plugins/Krtya.CRM/Views/CRM/Dashboard.cshtml");
        }

        #region Company

        public ActionResult Company()
        {
            return View("~/Plugins/Krtya.CRM/Views/CRM/Company/Company.cshtml");
        }

        [HttpPost]
        public ActionResult CompanyList(DataSourceRequest command)
        {
            var companies = _companyServices.GetAllCompanies(command.Page - 1, command.PageSize);
            var gridModel = new DataSourceResult
            {
                Data = companies.Select(x =>
                {
                    var companyModel = new CompanyModel();
                    companyModel.Id = x.Id;
                    companyModel.CompanyName = x.CompanyName;
                    return companyModel;
                }),
                Total = companies.TotalCount,
            };
            return Json(gridModel);
        }

        public ActionResult CreateCompany()
        {
            var model = new CompanyModel();

            model.AvailableCountries.Add(new SelectListItem() { Text = _localizationService.GetResource("Admin.Address.SelectCountry"), Value = "0" });
            foreach (var c in _countryService.GetAllCountries(true))
            {
                model.AvailableCountries.Add(new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            }

            //states
            var states = _stateProvinceService.GetStateProvincesByCountryId(model.CountryId.HasValue?model.CountryId.Value:0).ToList();
            if (states.Count > 0)
            {
                foreach (var s in states)
                    model.AvailableStates.Add(new SelectListItem() { Text = s.Name, Value = s.Id.ToString(), Selected = (s.Id == model.StateProvinceId) });
            }
            else
                model.AvailableStates.Add(new SelectListItem() { Text = _localizationService.GetResource("Admin.Address.OtherNonUS"), Value = "0" });


            return View("~/Plugins/Krtya.CRM/Views/CRM/Company/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult CreateCompany(CompanyModel model)
        {
            var company = new Company();

            company.CompanyName = model.CompanyName;
            company.Email = model.Email;
            company.Description = model.Description;
            company.Description = model.Description;
            company.Address1 = model.Address1;
            company.Address2 = model.Address2;
            company.ZipPostalCode = model.ZipPostalCode;
            company.City = model.City;
            company.CountryId = model.CountryId;
            company.StateProvinceId = model.StateProvinceId;
            company.PhoneNumber = model.PhoneNumber;
            company.FaxNumber = company.FaxNumber;
            
            company.CreatedDate = DateTime.UtcNow;
            company.UpdatedDate = DateTime.UtcNow;

            _companyServices.InsertCompany(company);

            return RedirectToAction("Company");
        }

        public ActionResult CompanyDetail(int companyId)
        {
            var model = new CompanyModel();
            var company = _companyServices.GetCompanyById(companyId);
            PrepareCompanyModel(model, company);

            return View("~/Plugins/Krtya.CRM/Views/CRM/Company/Details.cshtml", model);
        }

        public ActionResult CompanyEdit(int companyId)
        {
            var model = new CompanyModel();
            var company = _companyServices.GetCompanyById(companyId);
            PrepareCompanyModel(model, company);


            model.AvailableCountries.Add(new SelectListItem() { Text = _localizationService.GetResource("Admin.Address.SelectCountry"), Value = "0" });
            foreach (var c in _countryService.GetAllCountries(true))
            {
                model.AvailableCountries.Add(new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            }

            //states
            var states = _stateProvinceService.GetStateProvincesByCountryId(model.CountryId.HasValue ? model.CountryId.Value : 0).ToList();
            if (states.Count > 0)
            {
                foreach (var s in states)
                    model.AvailableStates.Add(new SelectListItem() { Text = s.Name, Value = s.Id.ToString(), Selected = (s.Id == model.StateProvinceId) });
            }
            else
                model.AvailableStates.Add(new SelectListItem() { Text = _localizationService.GetResource("Admin.Address.OtherNonUS"), Value = "0" });


            return View("~/Plugins/Krtya.CRM/Views/CRM/Company/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult CompanyEdit(CompanyModel model)
        {
            //TODO Check company is exist or not 
            var company = _companyServices.GetCompanyById(model.Id);
            company.CompanyName = model.CompanyName;
            company.Email = model.Email;
            company.Description = model.Description;
            company.Description = model.Description;
            company.Address1 = model.Address1;
            company.Address2 = model.Address2;
            company.ZipPostalCode = model.ZipPostalCode;
            company.City = model.City;
            company.CountryId = model.CountryId;
            company.StateProvinceId = model.StateProvinceId;
            company.PhoneNumber = model.PhoneNumber;
            company.FaxNumber = company.FaxNumber;

            
            company.UpdatedDate = DateTime.UtcNow;

            _companyServices.UpdateCompany(company);

            return CompanyDetail(model.Id);
        }
        #endregion
    }
}
