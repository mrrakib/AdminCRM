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
    public interface ICompanySocialProfileService
    {
        IPagedList GetCompanySocialProfilePaged(Page page);

        List<CompanySocialProfile> GetAllCompanySocialProfiles();
        CompanySocialProfile GetCompanyProfileDetails(int companyId);
        bool AddCompanySocialProfile(CompanySocialProfile profile);
        bool UpdateCompanySocialProfile(CompanySocialProfile company);
        bool SaveCompanySocialProfile();

        bool DeleteCompanySocialProfile(int Id);
    }
    public class CompanySocialProfileService : ICompanySocialProfileService
    {
        private readonly ICompanySocialProfileRepository _companySocialProfileRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CompanySocialProfileService(ICompanySocialProfileRepository companySocialProfileRepository, IUnitOfWork unitOfWork)
        {
            _companySocialProfileRepository = companySocialProfileRepository;
            _unitOfWork = unitOfWork;
        }

        public bool AddCompanySocialProfile(CompanySocialProfile profile)
        {
            _companySocialProfileRepository.Add(profile);
            return SaveCompanySocialProfile();
        }

        public bool DeleteCompanySocialProfile(int Id)
        {
            var companySocialProfile = _companySocialProfileRepository.Get(c => c.Id == Id);
            _companySocialProfileRepository.Delete(companySocialProfile);
            return SaveCompanySocialProfile();
        }

        public List<CompanySocialProfile> GetAllCompanySocialProfiles()
        {
            return _companySocialProfileRepository.GetAll().ToList();
        }

        public CompanySocialProfile GetCompanyProfileDetails(int Id)
        {
            return _companySocialProfileRepository.GetById(Id);
        }

        public IPagedList GetCompanySocialProfilePaged(Page page)
        {
            return _companySocialProfileRepository.GetPage(page, x => true, order => order.Id);
        }

        public bool SaveCompanySocialProfile()
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

        public bool UpdateCompanySocialProfile(CompanySocialProfile profile)
        {
            _companySocialProfileRepository.Update(profile);
            return SaveCompanySocialProfile();
        }
    }
}
