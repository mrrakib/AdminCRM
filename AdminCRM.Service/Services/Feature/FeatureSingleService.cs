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
    public interface IFeatureSingleService
    {
        IPagedList GetPaged(Page page);

        List<FeatureSingle> GetAll();
        FeatureSingle GetDetails(int Id);
        bool Add(FeatureSingle model);
        bool Update(FeatureSingle model);
        bool Save();
        bool Delete(int Id);
    }
    public class FeatureSingleService : IFeatureSingleService
    {
        private readonly IFeatureSingleRepository _featureSingleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FeatureSingleService(IFeatureSingleRepository featureSingleRepository, IUnitOfWork unitOfWork)
        {
            _featureSingleRepository = featureSingleRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Add(FeatureSingle model)
        {
            _featureSingleRepository.Add(model);
            return Save();
        }

        public bool Delete(int Id)
        {
            var featureSingle = _featureSingleRepository.Get(c => c.Id == Id);
            _featureSingleRepository.Delete(featureSingle);
            return Save();
        }

        public List<FeatureSingle> GetAll()
        {
            return _featureSingleRepository.GetAll().ToList();
        }

        public FeatureSingle GetDetails(int Id)
        {
            return _featureSingleRepository.GetById(Id);
        }

        public IPagedList GetPaged(Page page)
        {
            return _featureSingleRepository.GetPage(page, x => true, order => order.Id);
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

        public bool Update(FeatureSingle model)
        {
            _featureSingleRepository.Update(model);
            return Save();
        }
    }
}
