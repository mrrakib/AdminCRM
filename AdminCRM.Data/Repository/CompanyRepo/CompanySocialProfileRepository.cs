﻿using AdminCRM.Data.Infrastructure;
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
    public class CompanySocialProfileRepository : Repository<CompanySocialProfile>, ICompanySocialProfileRepository
    {
        AdminContext _context;
        public CompanySocialProfileRepository(DbContext context)
            : base(context)
        {
            _context = (AdminContext)context;
        }

    }
    public interface ICompanySocialProfileRepository : IRepository<CompanySocialProfile>
    {
        
    }
}
