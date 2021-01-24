using AdminCRM.Data.Infrastructure;
using AdminCRM.Data.Repository.About;
using AdminCRM.Data.Repository.Feature;
using AdminCRM.Data.Repository.Service;
using AdminCRM.Model.Models.CompanyDetails;
using AdminCRM.Model.Models.Sections;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCRM.Service.Services.Feature
{
    public interface ITeamMemberService
    {
        IPagedList GetPaged(Page page);

        List<TeamMember> GetAll();
        TeamMember GetDetails(int Id);
        bool Add(TeamMember model);
        bool Update(TeamMember model);
        bool Save();
        bool Delete(int Id);
    }
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TeamMemberService(ITeamMemberRepository teamMemberRepository, IUnitOfWork unitOfWork)
        {
            _teamMemberRepository = teamMemberRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Add(TeamMember model)
        {
            _teamMemberRepository.Add(model);
            return Save();
        }

        public bool Delete(int Id)
        {
            var teamMember = _teamMemberRepository.Get(c => c.Id == Id);
            _teamMemberRepository.Delete(teamMember);
            return Save();
        }

        public List<TeamMember> GetAll()
        {
            return _teamMemberRepository.GetAll().ToList();
        }

        public TeamMember GetDetails(int Id)
        {
            return _teamMemberRepository.GetById(Id);
        }

        public IPagedList GetPaged(Page page)
        {
            return _teamMemberRepository.GetPage(page, x => true, order => order.Id);
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

        public bool Update(TeamMember model)
        {
            _teamMemberRepository.Update(model);
            return Save();
        }
    }
}
