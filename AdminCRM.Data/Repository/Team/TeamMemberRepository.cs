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

namespace AdminCRM.Data.Repository.Feature
{
    public class TeamMemberRepository : Repository<TeamMember>, ITeamMemberRepository
    {
        AdminContext _context;
        public TeamMemberRepository(DbContext context)
            : base(context)
        {
            _context = (AdminContext)context;
        }

    }
    public interface ITeamMemberRepository : IRepository<TeamMember>
    {
        
    }
}
