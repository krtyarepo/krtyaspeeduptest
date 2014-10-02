using Krtya.CRM.Domain;
using Nop.Core;
using System.Collections.Generic;

namespace Krtya.CRM.Services
{
    public interface IPersonServices
    {
        /// <summary>
        /// Insert Person
        /// </summary>
        /// <param name="person">Person</param>
        void InsertPerson(Person person);

        /// <summary>
        /// Update Person
        /// </summary>
        /// <param name="person">Person</param>
        void UpdatePerson(Person person);


        /// <summary>
        /// Get Person By Id
        /// </summary>
        /// <param name="personId">Person Id</param>
        /// <returns></returns>
        Person GetPersonById(int personId);


        /// <summary>
        /// Get all Person
        /// </summary>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="showHidden">Show Hidden</param>
        /// <returns></returns>
        IPagedList<Person> GetAllPersons(int pageIndex = 0, int pageSize = 2147483647, bool showHidden = false);

        /// <summary>
        /// Get Persons By name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        IList<Person> GetPersonsByName(string name);

        /// <summary>
        /// Get Company Person By Company Id
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns></returns>
        IList<CompanyPersonMapping> GetCompanyPersonsByCompanyId(int companyId);


        #region Company Person Mapping

        /// <summary>
        /// Insert Company Person Mapping
        /// </summary>
        /// <param name="companyPersonMapping">company person mapping</param>
        void InsertCompanyPersonMapping(CompanyPersonMapping companyPersonMapping);

        /// <summary>
        /// Delete Company Person Mapping
        /// </summary>
        /// <param name="companyPersonMapping">company person mapping</param>
        void DeleteCompanyPersonMapping(CompanyPersonMapping companyPersonMapping);
        

        /// <summary>
        /// Get CompanyPersonMapping ByCompanyId PersonId
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <param name="personId">Person Id</param>
        /// <returns></returns>
        CompanyPersonMapping GetCompanyPersonMappingByCompanyIdPersonId(int companyId, int personId);
        
        
        #endregion
    }
}
