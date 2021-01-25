using AdminCRM.Service.Services.About;
using AdminCRM.Service.Services.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminCRM.Controllers
{
    public class HomeController : Controller
    {
        #region Global Variables
        private readonly ICompanyService _companyService;
        private readonly ICompanySocialProfileService _companySocialProfileService;
        private readonly IAboutSectionService _aboutSectionService;
        private readonly IExperienceSectionService _experienceSectionService;
        private readonly IWorkProcessSectionService _workProcessSectionService;
        private readonly IOurServiceMainService _serviceMainService;
        private readonly IServiceSingleService _singleService;

        public HomeController(ICompanyService companyService, ICompanySocialProfileService companySocialProfileService, IAboutSectionService aboutSectionService, IExperienceSectionService experienceSectionService, IWorkProcessSectionService workProcessSectionService, IOurServiceMainService serviceMainService, IServiceSingleService singleService)
        {
            _companyService = companyService;
            _companySocialProfileService = companySocialProfileService;
            _aboutSectionService = aboutSectionService;
            _experienceSectionService = experienceSectionService;
            _workProcessSectionService = workProcessSectionService;
            _serviceMainService = serviceMainService;
            _singleService = singleService;
        }
        #endregion

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.CompanyBasic = _companyService.GetTopOneCompany();
            ViewBag.CompanyProfileList = _companySocialProfileService.GetAllCompanySocialProfiles();
            ViewBag.AboutUsSection = _aboutSectionService.GetTopOneAboutUs();
            ViewBag.Experience = _experienceSectionService.GetTopOneExperience();
            ViewBag.WorkProcess = _workProcessSectionService.GetTopOne();
            ViewBag.SingleService = _serviceMainService.GetTopOne();
            ViewBag.SingleServiceList = _singleService.GetAll();
            return View();
        }
    }
}