using AdminCRM.Data.Infrastructure;
using AdminCRM.Data.Repository.CompanyRepo;
using AdminCRM.Model.Models.CompanyDetails;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Service.Services.CompanyServices
{
    public interface ICompanyService
    {
        IPagedList GetCompanyPaged(Page page);

        List<Company> GetAllCompanys();
        Company GetCompanyDetails(int companyId);
        bool AddCompany(Company company);
        bool UpdateCompany(Company company);
        bool SaveCompany();

        bool DeleteCompany(int companyId);
        Company GetTopOneCompany();
    }
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public bool AddCompany(Company company)
        {
            _companyRepository.Add(company);
            return SaveCompany();
        }

        public bool DeleteCompany(int companyId)
        {
            var company = _companyRepository.Get(c => c.Id == companyId);
            _companyRepository.Delete(company);
            return SaveCompany();
        }

        public List<Company> GetAllCompanys()
        {
            return _companyRepository.GetAll().ToList();
        }

        public Company GetCompanyDetails(int companyId)
        {
            return _companyRepository.GetById(companyId);
        }

        public IPagedList GetCompanyPaged(Page page)
        {
            return _companyRepository.GetPage(page, x => true, order => order.Id);
        }

        public Company GetTopOneCompany()
        {
            return _companyRepository.GetAll().FirstOrDefault();
        }

        public bool SaveCompany()
        {
            try
            {
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateCompany(Company company)
        {
            _companyRepository.Update(company);
            return SaveCompany();
        }
    }
}
