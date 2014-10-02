using Krtya.CRM.Domain;
using Nop.Core;

namespace Krtya.CRM.Services
{
    public interface ICompanyServices
    {
        /// <summary>
        /// Insert Company
        /// </summary>
        /// <param name="company">Company</param>
        void InsertCompany(Company company);

        /// <summary>
        /// Update Company
        /// </summary>
        /// <param name="company">Company</param>
        void UpdateCompany(Company company);
        

        /// <summary>
        /// Get Company By Id
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns></returns>
        Company GetCompanyById(int companyId);
        
        
        /// <summary>
        /// Get all companies
        /// </summary>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="showHidden">Show Hidden</param>
        /// <returns></returns>
        IPagedList<Company> GetAllCompanies(int pageIndex = 0, int pageSize = 2147483647, bool showHidden = false);

    }
}
