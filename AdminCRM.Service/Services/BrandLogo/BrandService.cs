using AdminCRM.Data.Infrastructure;
using AdminCRM.Data.Repository.Service;
using AdminCRM.Model.Models.Sections;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Service.Services.BrandLogo
{
    public interface IBrandService
    {
        IPagedList GetPaged(Page page);

        List<Brands> GetAll();
        Brands GetDetails(int Id);
        bool Add(Brands model);
        bool Update(Brands model);
        bool Save();
        bool Delete(int Id);
    }
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BrandService(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Add(Brands model)
        {
            _brandRepository.Add(model);
            return Save();
        }

        public bool Delete(int Id)
        {
            var brand = _brandRepository.Get(c => c.Id == Id);
            _brandRepository.Delete(brand);
            return Save();
        }

        public List<Brands> GetAll()
        {
            return _brandRepository.GetAll().ToList();
        }

        public Brands GetDetails(int Id)
        {
            return _brandRepository.GetById(Id);
        }

        public IPagedList GetPaged(Page page)
        {
            return _brandRepository.GetPage(page, x => true, order => order.Id);
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

        public bool Update(Brands model)
        {
            _brandRepository.Update(model);
            return Save();
        }
    }
}
