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
    public class AboutSectionRepository : Repository<AboutSection>, IAboutSectionRepository
    {
        AdminContext _context;
        public AboutSectionRepository(DbContext context)
            : base(context)
        {
            _context = (AdminContext)context;
        }

    }
    public interface IAboutSectionRepository : IRepository<AboutSection>
    {
        
    }
}
