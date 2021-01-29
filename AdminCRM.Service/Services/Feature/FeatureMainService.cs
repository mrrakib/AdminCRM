using AdminCRM.Data.Infrastructure;
using AdminCRM.Data.Repository.About;
using AdminCRM.Data.Repository.Feature;
using AdminCRM.Data.Repository.Service;
using AdminCRM.Model.Models.CompanyDetails;
using AdminCRM.Model.Models.Sections;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Service.Services.Feature
{
    public interface IFeatureMainService
    {
        IPagedList GetPaged(Page page);

        List<FeatureMain> GetAll();
        FeatureMain GetDetails(int Id);
        bool Add(FeatureMain model);
        bool Update(FeatureMain model);
        bool Save();
        bool Delete(int Id);
        FeatureMain GetTopOne();
    }
    public class FeatureMainService : IFeatureMainService
    {
        private readonly IFeatureMainRepository _featureMainRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FeatureMainService(IFeatureMainRepository featureMainRepository, IUnitOfWork unitOfWork)
        {
            _featureMainRepository = featureMainRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Add(FeatureMain model)
        {
            _featureMainRepository.Add(model);
            return Save();
        }

        public bool Delete(int Id)
        {
            var featureMain = _featureMainRepository.Get(c => c.Id == Id);
            _featureMainRepository.Delete(featureMain);
            return Save();
        }

        public List<FeatureMain> GetAll()
        {
            return _featureMainRepository.GetAll().ToList();
        }

        public FeatureMain GetDetails(int Id)
        {
            return _featureMainRepository.GetById(Id);
        }

        public IPagedList GetPaged(Page page)
        {
            return _featureMainRepository.GetPage(page, x => true, order => order.Id);
        }

        public FeatureMain GetTopOne()
        {
            return _featureMainRepository.GetAll().FirstOrDefault();
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

        public bool Update(FeatureMain model)
        {
            _featureMainRepository.Update(model);
            return Save();
        }
    }
}
