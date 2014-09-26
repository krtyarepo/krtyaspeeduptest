using Krtya.CRM.Models;
using Krtya.CRM.Services;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Kendoui;
using System.Web.Mvc;
using System.Linq;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Krtya.CRM.Domain;
using System;
using Nop.Services.Media;
using Nop.Core.Domain.Media;

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
        private readonly IPictureService _pictureService;
        private readonly MediaSettings _mediaSettings;
        private readonly IPersonServices _personServices;
        #endregion

        #region Ctor

        public CRMController(ICompanyServices companyServices, ICountryService countryService,
            IStateProvinceService stateProvinceService, ILocalizationService localizationService,
            IPictureService pictureService, MediaSettings mediaSettings,
            IPersonServices personServices)
        {
            _companyServices = companyServices;
            _countryService = countryService;
            _stateProvinceService = stateProvinceService;
            _localizationService = localizationService;
            _pictureService = pictureService;
            _mediaSettings = mediaSettings;
            _personServices = personServices;
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
            model.WebsiteURL = company.WebsiteURL;
            model.Description = company.Description;
            model.ContactTypeId = company.ContactTypeId;
            model.ContactTypeName = company.ContactTypeEnum.ToString();
            model.Address1 = company.Address1;
            model.Address2 = company.Address2;
            model.ZipPostalCode = company.ZipPostalCode;
            model.City = company.City;
            model.CountryId = company.CountryId;
            model.FaxNumber = company.FaxNumber;
            model.PictureId = company.PictureId;
            model.PictureUrl = _pictureService.GetPictureUrl(company.PictureId);
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

        [NonAction]
        protected virtual void PreparePersonModel(PersonModel model, Person person)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.Id = person.Id;
            model.FirstName = person.FirstName;
            model.LastName = person.LastName;
            model.Email = person.Email;
            model.Position = person.Position;
            model.Description = person.Description;
            model.Address1 = person.Address1;
            model.Address2 = person.Address2;
            model.ZipPostalCode = person.ZipPostalCode;
            model.City = person.City;
            model.CountryId = person.CountryId;
            model.FaxNumber = person.FaxNumber;
            model.PictureId = person.PictureId;
            model.PictureUrl = _pictureService.GetPictureUrl(person.PictureId);
            if (person.CountryId.HasValue && person.CountryId.Value > 0)
            {
                model.CountryName = _countryService.GetCountryById(person.CountryId.Value).Name.ToString();
            }
            model.StateProvinceId = person.StateProvinceId;

            if (person.StateProvinceId.HasValue && person.StateProvinceId.Value > 0)
            {
                model.StateProvinceName = _stateProvinceService.GetStateProvinceById(person.StateProvinceId.Value).Name.ToString();
            }
            model.PhoneNumber = person.PhoneNumber;
            model.FaxNumber = person.FaxNumber;
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
                    companyModel.PictureUrl = _pictureService.GetPictureUrl(x.PictureId, _mediaSettings.AvatarPictureSize, defaultPictureType: Nop.Core.Domain.Media.PictureType.Avatar);
                    companyModel.CompanyName = x.CompanyName;
                    companyModel.Email = x.Email;
                    companyModel.WebsiteURL = x.WebsiteURL;
                    companyModel.PhoneNumber = x.PhoneNumber;
                    return companyModel;
                }),
                Total = companies.TotalCount,
            };
            return Json(gridModel);
        }

        public ActionResult CreateCompany()
        {
            var model = new CompanyModel();

            //Contact Type
            model.AvailableContactType = ContactTypeEnum.None.ToSelectList(false).ToList();
            


            //Country
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
            company.WebsiteURL = model.WebsiteURL;
            company.ContactTypeId = model.ContactTypeId;
            company.Description = model.Description;
            company.PictureId = model.PictureId;
            company.Address1 = model.Address1;
            company.Address2 = model.Address2;
            company.ZipPostalCode = model.ZipPostalCode;
            company.City = model.City;
            company.CountryId = model.CountryId;
            company.StateProvinceId = model.StateProvinceId;
            company.PhoneNumber = model.PhoneNumber;
            company.FaxNumber = model.FaxNumber;
            
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

            //Contact Type
            model.AvailableContactType = ContactTypeEnum.None.ToSelectList(false).ToList();
            

            //Country
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
            company.WebsiteURL = model.WebsiteURL;
            company.Description = model.Description;
            company.ContactTypeId = model.ContactTypeId;
            company.PictureId = model.PictureId;
            company.Address1 = model.Address1;
            company.Address2 = model.Address2;
            company.ZipPostalCode = model.ZipPostalCode;
            company.City = model.City;
            company.CountryId = model.CountryId;
            company.StateProvinceId = model.StateProvinceId;
            company.PhoneNumber = model.PhoneNumber;
            company.FaxNumber = model.FaxNumber;

            
            company.UpdatedDate = DateTime.UtcNow;

            _companyServices.UpdateCompany(company);

            return RedirectToAction("CompanyDetail", new { companyId=model.Id });
        }
        #endregion

        #region Person

        public ActionResult Person()
        {
            return View("~/Plugins/Krtya.CRM/Views/CRM/Person/Person.cshtml");
        }

        [HttpPost]
        public ActionResult PersonList(DataSourceRequest command)
        {
            var persons = _personServices.GetAllPersons(command.Page - 1, command.PageSize);
            var gridModel = new DataSourceResult
            {
                Data = persons.Select(x =>
                {
                    var personModel = new PersonModel();
                    personModel.Id = x.Id;
                    personModel.PictureUrl = _pictureService.GetPictureUrl(x.PictureId, _mediaSettings.AvatarPictureSize, defaultPictureType: Nop.Core.Domain.Media.PictureType.Avatar);
                    personModel.FirstName = x.FirstName +" " + x.LastName;
                    personModel.Email = x.Email;
                    personModel.Position = x.Position;
                    personModel.PhoneNumber = x.PhoneNumber;
                    return personModel;
                }),
                Total = persons.TotalCount,
            };
            return Json(gridModel);
        }

        public ActionResult CreatePerson()
        {
            var model = new PersonModel();

            
            //Country
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


            return View("~/Plugins/Krtya.CRM/Views/CRM/Person/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreatePerson(PersonModel model)
        {
            var person = new Person();

            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            person.Email = model.Email;
            person.Position = model.Position;
            person.Description = model.Description;
            person.PictureId = model.PictureId;
            person.Address1 = model.Address1;
            person.Address2 = model.Address2;
            person.ZipPostalCode = model.ZipPostalCode;
            person.City = model.City;
            person.CountryId = model.CountryId;
            person.StateProvinceId = model.StateProvinceId;
            person.PhoneNumber = model.PhoneNumber;
            person.FaxNumber = model.FaxNumber;

            person.CreatedDate = DateTime.UtcNow;
            person.UpdatedDate = DateTime.UtcNow;

            _personServices.InsertPerson(person);

            return RedirectToAction("Person");
        }

        public ActionResult PersonDetail(int personId)
        {
            var model = new PersonModel();
            var person = _personServices.GetPersonById(personId);
            PreparePersonModel(model, person);

            return View("~/Plugins/Krtya.CRM/Views/CRM/Person/Details.cshtml", model);
        }

        public ActionResult PersonEdit(int personId)
        {
            var model = new PersonModel();
            var person = _personServices.GetPersonById(personId);
            PreparePersonModel(model, person);

            
            //Country
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


            return View("~/Plugins/Krtya.CRM/Views/CRM/Person/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult PersonEdit(PersonModel model)
        {
            //TODO Check person is exist or not 
            var person = _personServices.GetPersonById(model.Id);
            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            person.Email = model.Email;
            person.Position = model.Position;
            person.Description = model.Description;
            person.PictureId = model.PictureId;
            person.Address1 = model.Address1;
            person.Address2 = model.Address2;
            person.ZipPostalCode = model.ZipPostalCode;
            person.City = model.City;
            person.CountryId = model.CountryId;
            person.StateProvinceId = model.StateProvinceId;
            person.PhoneNumber = model.PhoneNumber;
            person.FaxNumber = model.FaxNumber;


            person.UpdatedDate = DateTime.UtcNow;

            _personServices.UpdatePerson(person);

            return RedirectToAction("PersonDetail", new { personId = model.Id });
        }
        #endregion
    }
}
