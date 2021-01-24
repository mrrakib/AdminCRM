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

namespace AdminCRM.Data.Repository.About
{
    public class ExperienceSectionRepository : Repository<ExperienceSection>, IExperienceSectionRepository
    {
        AdminContext _context;
        public ExperienceSectionRepository(DbContext context)
            : base(context)
        {
            _context = (AdminContext)context;
        }

    }
    public interface IExperienceSectionRepository : IRepository<ExperienceSection>
    {
        
    }
}
