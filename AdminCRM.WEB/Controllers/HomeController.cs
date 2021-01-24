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

        public HomeController(ICompanyService companyService, ICompanySocialProfileService companySocialProfileService, IAboutSectionService aboutSectionService)
        {
            _companyService = companyService;
            _companySocialProfileService = companySocialProfileService;
            _aboutSectionService = aboutSectionService;
        }
        #endregion

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.CompanyBasic = _companyService.GetTopOneCompany();
            ViewBag.CompanyProfileList = _companySocialProfileService.GetAllCompanySocialProfiles();
            ViewBag.AboutUsSection = _aboutSectionService.GetTopOneAboutUs();
            return View();
        }
    }
}