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
    public interface IOurServiceMainService
    {
        IPagedList GetPaged(Page page);

        List<OurServiceMain> GetAll();
        OurServiceMain GetDetails(int Id);
        bool Add(OurServiceMain model);
        bool Update(OurServiceMain model);
        bool Save();
        bool Delete(int Id);
        OurServiceMain GetTopOne();
    }
    public class OursServiceMainService : IOurServiceMainService
    {
        private readonly IOurServiceMainRepository _ourServiceMainRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OursServiceMainService(IOurServiceMainRepository ourServiceMainRepository, IUnitOfWork unitOfWork)
        {
            _ourServiceMainRepository = ourServiceMainRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Add(OurServiceMain model)
        {
            _ourServiceMainRepository.Add(model);
            return Save();
        }

        public bool Delete(int Id)
        {
            var serviceMain = _ourServiceMainRepository.Get(c => c.Id == Id);
            _ourServiceMainRepository.Delete(serviceMain);
            return Save();
        }

        public List<OurServiceMain> GetAll()
        {
            return _ourServiceMainRepository.GetAll().ToList();
        }
        public OurServiceMain GetTopOne()
        {
            return _ourServiceMainRepository.GetAll().FirstOrDefault();
        }

        public OurServiceMain GetDetails(int Id)
        {
            return _ourServiceMainRepository.GetById(Id);
        }

        public IPagedList GetPaged(Page page)
        {
            return _ourServiceMainRepository.GetPage(page, x => true, order => order.Id);
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

        public bool Update(OurServiceMain model)
        {
            _ourServiceMainRepository.Update(model);
            return Save();
        }
    }
}
