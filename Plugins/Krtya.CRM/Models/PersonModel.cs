﻿using Nop.Web.Framework.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Krtya.CRM.Models
{
    public class PersonModel : BaseNopEntityModel
    {
        public PersonModel()
        {
            this.AvailableCountries = new List<SelectListItem>();
            this.AvailableStates = new List<SelectListItem>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        [UIHint("Picture")]
        public int PictureId { get; set; }

        public string PictureUrl { get; set; }

        public string Description { get; set; }

        public string Position { get; set; }

        public string City { get; set; }

        public int? CountryId { get; set; }

        public string CountryName { get; set; }

        public int? StateProvinceId { get; set; }

        public string StateProvinceName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string ZipPostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public IList<SelectListItem> AvailableCountries { get; set; }

        public IList<SelectListItem> AvailableStates { get; set; }

    }
}
