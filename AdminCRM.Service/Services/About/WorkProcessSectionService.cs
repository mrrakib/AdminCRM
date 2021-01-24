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
    public interface IWorkProcessSectionService
    {
        IPagedList GetPaged(Page page);

        List<WorkProcessSection> GetAll();
        WorkProcessSection GetDetails(int Id);
        bool Add(WorkProcessSection model);
        bool Update(WorkProcessSection model);
        bool Save();
        bool Delete(int Id);
    }
    public class WorkProcessSectionService : IWorkProcessSectionService
    {
        private readonly IWorkProcessSectionRepository _workProcessSectionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public WorkProcessSectionService(IWorkProcessSectionRepository workProcessSectionRepository, IUnitOfWork unitOfWork)
        {
            _workProcessSectionRepository = workProcessSectionRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Add(WorkProcessSection model)
        {
            _workProcessSectionRepository.Add(model);
            return Save();
        }

        public bool Delete(int Id)
        {
            var workProcess = _workProcessSectionRepository.Get(c => c.Id == Id);
            _workProcessSectionRepository.Delete(workProcess);
            return Save();
        }

        public List<WorkProcessSection> GetAll()
        {
            return _workProcessSectionRepository.GetAll().ToList();
        }

        public WorkProcessSection GetDetails(int Id)
        {
            return _workProcessSectionRepository.GetById(Id);
        }

        public IPagedList GetPaged(Page page)
        {
            return _workProcessSectionRepository.GetPage(page, x => true, order => order.Id);
        }

        public bool Save()
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

        public bool Update(WorkProcessSection model)
        {
            _workProcessSectionRepository.Update(model);
            return Save();
        }
    }
}
