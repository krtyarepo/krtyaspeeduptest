using Krtya.CRM.Domain;
using Nop.Core;
using Nop.Core.Data;
using System;
using System.Linq;

namespace Krtya.CRM.Services
{
    public class CompanyServices : ICompanyServices
    {
        #region Fields

        private readonly IRepository<Company> _companyRepository;

        #endregion 

        #region Ctor

        public CompanyServices(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Insert Company
        /// </summary>
        /// <param name="company">Company</param>
        public virtual void InsertCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException("Company");

            _companyRepository.Insert(company);
        }

        /// <summary>
        /// Update Company
        /// </summary>
        /// <param name="company">Company</param>
        public virtual void UpdateCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException("Company");

            _companyRepository.Update(company);
        }


        /// <summary>
        /// Get Company By Id
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns></returns>
        public virtual Company GetCompanyById(int companyId)
        {
            if (companyId == 0)
                throw new ArgumentException("Company not found.");

            return _companyRepository.GetById(companyId);
        }
        
        /// <summary>
        /// Get all companies
        /// </summary>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="showHidden">Show Hidden</param>
        /// <returns></returns>
        public virtual IPagedList<Company> GetAllCompanies(int pageIndex, int pageSize,bool showHidden=false)
        {
            var query = _companyRepository.TableNoTracking;

            if (!showHidden)
            {
                query = query.Where(c => !c.Deleted);
            }

            query = query.OrderByDescending(l => l.Id);

            return new PagedList<Company>(query, pageIndex, pageSize);
        }


        #endregion

    }
}
