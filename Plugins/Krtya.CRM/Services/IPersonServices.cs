using Krtya.CRM.Domain;
using Nop.Core;

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
        IPagedList<Person> GetAllPersons(int pageIndex, int pageSize, bool showHidden = false);
    }
}
