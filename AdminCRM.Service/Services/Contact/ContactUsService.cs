using AdminCRM.Data.Infrastructure;
using AdminCRM.Model.Models.Sections;
using PagedList;
using RapidSale.Data.Repository.Contact;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminCRM.Service.Services.Contact
{
    public interface IContactUsService
    {
        IPagedList GetPaged(Page page);

        List<ContactUs> GetAll();
        ContactUs GetDetails(int Id);
        bool Add(ContactUs model);
        bool Update(ContactUs model);
        bool Save();
        bool Delete(int Id);
        ContactUs GetTopOne();
    }
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ContactUsService(IContactUsRepository contactUsRepository, IUnitOfWork unitOfWork)
        {
            _contactUsRepository = contactUsRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Add(ContactUs model)
        {
            _contactUsRepository.Add(model);
            return Save();
        }

        public bool Delete(int Id)
        {
            var contactUs = _contactUsRepository.Get(c => c.Id == Id);
            _contactUsRepository.Delete(contactUs);
            return Save();
        }

        public List<ContactUs> GetAll()
        {
            return _contactUsRepository.GetAll().ToList();
        }

        public ContactUs GetDetails(int Id)
        {
            return _contactUsRepository.GetById(Id);
        }

        public IPagedList GetPaged(Page page)
        {
            return _contactUsRepository.GetPage(page, x => true, order => order.Id);
        }

        public ContactUs GetTopOne()
        {
            return _contactUsRepository.GetAll().FirstOrDefault();
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

        public bool Update(ContactUs model)
        {
            _contactUsRepository.Update(model);
            return Save();
        }
    }
}
