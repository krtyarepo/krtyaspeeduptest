using Krtya.CRM.Domain;
using Nop.Core;
using Nop.Core.Data;
using System;
using System.Linq;
namespace Krtya.CRM.Services
{
    public class PersonServices : IPersonServices
    {
          #region Fields

        private readonly IRepository<Person> _personRepository;

        #endregion 

        #region Ctor

        public PersonServices(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
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
        public virtual IPagedList<Person> GetAllPersons(int pageIndex, int pageSize,bool showHidden=false)
        {
            var query = _personRepository.Table;

            if (!showHidden)
            {
                query = query.Where(c => !c.Deleted);
            }

            query = query.OrderByDescending(l => l.Id);

            return new PagedList<Person>(query, pageIndex, pageSize);
        }


        #endregion

    }
}
