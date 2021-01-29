using AdminCRM.Data.Infrastructure;
using AdminCRM.Model.Models.CompanyDetails;
using System.Data.Entity;

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
