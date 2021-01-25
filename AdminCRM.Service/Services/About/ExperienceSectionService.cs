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
    public interface IExperienceSectionService
    {
        IPagedList GetExperiencePaged(Page page);

        List<ExperienceSection> GetAllExperience();
        ExperienceSection GetExperienceDetails(int Id);
        bool AddExperienceSection(ExperienceSection model);
        bool UpdateExperienceSection(ExperienceSection model);
        bool SaveExperienceSection();
        ExperienceSection GetTopOneExperience();
        bool DeleteExperienceSection(int Id);
    }
    public class ExperienceSectionService : IExperienceSectionService
    {
        private readonly IExperienceSectionRepository _experienceSectionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ExperienceSectionService(IExperienceSectionRepository experienceSectionRepository, IUnitOfWork unitOfWork)
        {
            _experienceSectionRepository = experienceSectionRepository;
            _unitOfWork = unitOfWork;
        }

        public bool AddExperienceSection(ExperienceSection model)
        {
            _experienceSectionRepository.Add(model);
            return SaveExperienceSection();
        }

        public bool DeleteExperienceSection(int Id)
        {
            var experience = _experienceSectionRepository.Get(c => c.Id == Id);
            _experienceSectionRepository.Delete(experience);
            return SaveExperienceSection();
        }

        public List<ExperienceSection> GetAllExperience()
        {
            return _experienceSectionRepository.GetAll().ToList();
        }
        public ExperienceSection GetTopOneExperience()
        {
            return _experienceSectionRepository.GetAll().FirstOrDefault();
        }

        public ExperienceSection GetExperienceDetails(int Id)
        {
            return _experienceSectionRepository.GetById(Id);
        }

        public IPagedList GetExperiencePaged(Page page)
        {
            return _experienceSectionRepository.GetPage(page, x => true, order => order.Id);
        }

        public bool SaveExperienceSection()
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

        public bool UpdateExperienceSection(ExperienceSection model)
        {
            _experienceSectionRepository.Update(model);
            return SaveExperienceSection();
        }
    }
}
