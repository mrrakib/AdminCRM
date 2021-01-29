using AdminCRM.Data;
using AdminCRM.Data.Infrastructure;
using AdminCRM.Model.Models.Sections;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidSale.Data.Repository.Contact
{
    public class ContactUsRepository : Repository<ContactUs>, IContactUsRepository
    {
        AdminContext _context;
        public ContactUsRepository(DbContext context)
            : base(context)
        {
            _context = (AdminContext)context;
        }

    }
    public interface IContactUsRepository : IRepository<ContactUs>
    {

    }
}
