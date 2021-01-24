using AdminCRM.Data.Infrastructure;
using AdminCRM.Data.Repository.About;
using AdminCRM.Model.Models.CompanyDetails;
using AdminCRM.Model.Models.Sections;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Service.Services.About
{
    public interface IAboutSectionService
    {
        IPagedList GetAboutPaged(Page page);

        List<AboutSection> GetAllAbouts();
        AboutSection GetAboutDetails(int Id);
        bool AddAboutSection(AboutSection model);
        bool UpdateAboutSection(AboutSection model);
        bool SaveAboutSection();

        bool DeleteAboutSection(int Id);
    }
    public class AboutSectionService : IAboutSectionService
    {
        private readonly IAboutSectionRepository _aboutSectionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AboutSectionService(IAboutSectionRepository aboutSectionRepository, IUnitOfWork unitOfWork)
        {
            _aboutSectionRepository = aboutSectionRepository;
            _unitOfWork = unitOfWork;
        }

        public bool AddAboutSection(AboutSection model)
        {
            _aboutSectionRepository.Add(model);
            return SaveAboutSection();
        }

        public bool DeleteAboutSection(int Id)
        {
            var company = _aboutSectionRepository.Get(c => c.Id == Id);
            _aboutSectionRepository.Delete(company);
            return SaveAboutSection();
        }

        public List<AboutSection> GetAllAbouts()
        {
            return _aboutSectionRepository.GetAll().ToList();
        }

        public AboutSection GetAboutDetails(int Id)
        {
            return _aboutSectionRepository.GetById(Id);
        }

        public IPagedList GetAboutPaged(Page page)
        {
            return _aboutSectionRepository.GetPage(page, x => true, order => order.Id);
        }

        public bool SaveAboutSection()
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

        public bool UpdateAboutSection(AboutSection model)
        {
            _aboutSectionRepository.Update(model);
            return SaveAboutSection();
        }
    }
}
