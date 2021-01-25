using AdminCRM.Data.Infrastructure;
using AdminCRM.Data.Repository.About;
using AdminCRM.Data.Repository.Service;
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
    public interface IServiceSingleService
    {
        IPagedList GetPaged(Page page);

        List<ServiceSingle> GetAll();
        ServiceSingle GetDetails(int Id);
        bool Add(ServiceSingle model);
        bool Update(ServiceSingle model);
        bool Save();
        bool Delete(int Id);
        ServiceSingle GetTopOne();
    }
    public class ServiceSingleService : IServiceSingleService
    {
        private readonly IServiceSingleRepository _serviceSingleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ServiceSingleService(IServiceSingleRepository serviceSingleRepository, IUnitOfWork unitOfWork)
        {
            _serviceSingleRepository = serviceSingleRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Add(ServiceSingle model)
        {
            _serviceSingleRepository.Add(model);
            return Save();
        }

        public bool Delete(int Id)
        {
            var serviceSingle = _serviceSingleRepository.Get(c => c.Id == Id);
            _serviceSingleRepository.Delete(serviceSingle);
            return Save();
        }

        public List<ServiceSingle> GetAll()
        {
            return _serviceSingleRepository.GetAll().ToList();
        }
        public ServiceSingle GetTopOne()
        {
            return _serviceSingleRepository.GetAll().FirstOrDefault();
        }

        public ServiceSingle GetDetails(int Id)
        {
            return _serviceSingleRepository.GetById(Id);
        }

        public IPagedList GetPaged(Page page)
        {
            return _serviceSingleRepository.GetPage(page, x => true, order => order.Id);
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

        public bool Update(ServiceSingle model)
        {
            _serviceSingleRepository.Update(model);
            return Save();
        }
    }
}
