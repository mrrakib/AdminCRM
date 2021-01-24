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
    public interface ITeamService
    {
        IPagedList GetPaged(Page page);

        List<Team> GetAll();
        Team GetDetails(int Id);
        bool Add(Team model);
        bool Update(Team model);
        bool Save();
        bool Delete(int Id);
    }
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TeamService(ITeamRepository teamRepository, IUnitOfWork unitOfWork)
        {
            _teamRepository = teamRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Add(Team model)
        {
            _teamRepository.Add(model);
            return Save();
        }

        public bool Delete(int Id)
        {
            var team = _teamRepository.Get(c => c.Id == Id);
            _teamRepository.Delete(team);
            return Save();
        }

        public List<Team> GetAll()
        {
            return _teamRepository.GetAll().ToList();
        }

        public Team GetDetails(int Id)
        {
            return _teamRepository.GetById(Id);
        }

        public IPagedList GetPaged(Page page)
        {
            return _teamRepository.GetPage(page, x => true, order => order.Id);
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

        public bool Update(Team model)
        {
            _teamRepository.Update(model);
            return Save();
        }
    }
}
