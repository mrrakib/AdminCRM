using AdminCRM.Data.Infrastructure;
using AdminCRM.Model.Models.Account;
using AdminCRM.Model.Models.CompanyDetails;
using AdminCRM.Model.Models.Sections;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Data.Repository.Service
{
    public class ServiceSingleRepository : Repository<ServiceSingle>, IServiceSingleRepository
    {
        AdminContext _context;
        public ServiceSingleRepository(DbContext context)
            : base(context)
        {
            _context = (AdminContext)context;
        }

    }
    public interface IServiceSingleRepository : IRepository<ServiceSingle>
    {
        
    }
}
