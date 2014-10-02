using Krtya.CRM.Domain;
using Nop.Core;
using Nop.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Krtya.CRM.Services
{
    public class PersonServices : IPersonServices
    {
        #region Fields

        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<CompanyPersonMapping> _companyPersonMappingRepository;

        #endregion 

        #region Ctor

        public PersonServices(IRepository<Person> personRepository, IRepository<CompanyPersonMapping> companyPersonMappingRepository)
        {
            _personRepository = personRepository;
            _companyPersonMappingRepository = companyPersonMappingRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Insert Person
        /// </summary>
        /// <param name="person">Person</param>
        public virtual void InsertPerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException("Person");

            _personRepository.Insert(person);
        }

        /// <summary>
        /// Update Person
        /// </summary>
        /// <param name="person">Person</param>
        public virtual void UpdatePerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException("Person");

            _personRepository.Update(person);
        }


        /// <summary>
        /// Get Person By Id
        /// </summary>
        /// <param name="personId">Person Id</param>
        /// <returns></returns>
        public virtual Person GetPersonById(int personId)
        {
            if (personId == 0)
                throw new ArgumentException("Person not found.");

            return _personRepository.GetById(personId);
        }
        
        /// <summary>
        /// Get all person
        /// </summary>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="showHidden">Show Hidden</param>
        /// <returns></returns>
        public virtual IPagedList<Person> GetAllPersons(int pageIndex = 0, int pageSize = 2147483647,bool showHidden=false)
        {
            var query = _personRepository.TableNoTracking;

            if (!showHidden)
            {
                query = query.Where(c => !c.Deleted);
            }

            query = query.OrderByDescending(l => l.Id);

            return new PagedList<Person>(query, pageIndex, pageSize);
        }


        /// <summary>
        /// Get Persons By name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public virtual IList<Person> GetPersonsByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Person not found.");

            var query = _personRepository.TableNoTracking;

            query = query.Where(p => !p.Deleted);

            query = query.Where(p=>p.FirstName.ToLower().Contains(name.ToLower()) || p.LastName.ToLower().Contains(name.ToLower()));

            return query.ToList();
        }

        /// <summary>
        /// Get Company Person By Company Id
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns></returns>
        public virtual IList<CompanyPersonMapping> GetCompanyPersonsByCompanyId(int companyId)
        {
            if (companyId == 0)
                throw new ArgumentException("company not found.");

            var query = _companyPersonMappingRepository.TableNoTracking;

            query = query.Where(cp => cp.CompanyId == companyId);

            return query.ToList();
        }


        #region Company Person Mapping

        /// <summary>
        /// Insert Company Person Mapping
        /// </summary>
        /// <param name="companyPersonMapping">company person mapping</param>
        public virtual void InsertCompanyPersonMapping(CompanyPersonMapping companyPersonMapping)
        {
            if (companyPersonMapping == null)
                throw new NullReferenceException("Company Person Mapping is null.");

            _companyPersonMappingRepository.Insert(companyPersonMapping);
        }

        /// <summary>
        /// Delete Company Person Mapping
        /// </summary>
        /// <param name="companyPersonMapping">company person mapping</param>
        public virtual void DeleteCompanyPersonMapping(CompanyPersonMapping companyPersonMapping)
        {
            if (companyPersonMapping == null)
                throw new NullReferenceException("Company Person Mapping is null.");

            _companyPersonMappingRepository.Delete(_companyPersonMappingRepository.GetById(companyPersonMapping.Id));
        }

        /// <summary>
        /// Get CompanyPersonMapping ByCompanyId PersonId
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <param name="personId">Person Id</param>
        /// <returns></returns>
        public virtual CompanyPersonMapping GetCompanyPersonMappingByCompanyIdPersonId(int companyId, int personId)
        {
            var query = _companyPersonMappingRepository.TableNoTracking;

            query = query.Where(cp => cp.CompanyId.Equals(companyId) && cp.PersonId.Equals(personId));

            return query.FirstOrDefault();
        }

        #endregion

        #endregion

    }
}
