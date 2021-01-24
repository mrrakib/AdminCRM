using AdminCRM.Data.Infrastructure;
using AdminCRM.Model.Models.Account;
using AdminCRM.Model.Models.CompanyDetails;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Data.Repository.CompanyRepo
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        AdminContext _context;
        public CompanyRepository(DbContext context)
            : base(context)
        {
            _context = (AdminContext)context;
        }

    }
    public interface ICompanyRepository : IRepository<Company>
    {
        
    }
}
