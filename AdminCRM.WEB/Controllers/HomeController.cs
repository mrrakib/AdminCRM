using AdminCRM.Service.Services.About;
using AdminCRM.Service.Services.BrandLogo;
using AdminCRM.Service.Services.CompanyServices;
using AdminCRM.Service.Services.Contact;
using AdminCRM.Service.Services.Feature;
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
        private readonly IBrandService _brandService;
        private readonly IFeatureMainService _mainFeature;
        private readonly IFeatureSingleService _singleFeature;
        private readonly ITeamService _teamService;
        private readonly ITeamMemberService _teamMemberService;
        private readonly IContactUsService _contactUsService;

        public HomeController(ICompanyService companyService, ICompanySocialProfileService companySocialProfileService, IAboutSectionService aboutSectionService, IExperienceSectionService experienceSectionService, IWorkProcessSectionService workProcessSectionService, IOurServiceMainService serviceMainService, IServiceSingleService singleService, IBrandService brandService, IFeatureMainService mainFeature, IFeatureSingleService singleFeature, ITeamService teamService, ITeamMemberService teamMemberService, IContactUsService contactUsService)
        {
            _companyService = companyService;
            _companySocialProfileService = companySocialProfileService;
            _aboutSectionService = aboutSectionService;
            _experienceSectionService = experienceSectionService;
            _workProcessSectionService = workProcessSectionService;
            _serviceMainService = serviceMainService;
            _singleService = singleService;
            _brandService = brandService;
            _mainFeature = mainFeature;
            _singleFeature = singleFeature;
            _teamService = teamService;
            _teamMemberService = teamMemberService;
            _contactUsService = contactUsService;
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
            ViewBag.BrandLogoList = _brandService.GetAll();
            ViewBag.MainFeature = _mainFeature.GetTopOne();
            ViewBag.SingleFeatureList = _singleFeature.GetAll();
            ViewBag.TeamMain = _teamService.GetTopOne();
            ViewBag.TeamMemberList = _teamMemberService.GetAll();
            ViewBag.ContactUs = _contactUsService.GetTopOne();
            return View();
        }
    }
}