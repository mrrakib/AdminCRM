using AdminCRM.Data.Infrastructure;
using AdminCRM.Filter;
using AdminCRM.Helper;
using AdminCRM.Model.Models.CompanyDetails;
using AdminCRM.Service.Services.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminCRM.Controllers
{
    public class CompanySocialProfileController : Controller
    {
        #region Global Variables
        private readonly ICompanyService _companyService;
        private readonly ICompanySocialProfileService _companySocialProfileService;
        private readonly Message message = new Message();

        public CompanySocialProfileController(ICompanySocialProfileService companySocialProfileService, ICompanyService companyService)
        {
            _companySocialProfileService = companySocialProfileService;
            _companyService = companyService;
        }
        #endregion
        // GET: Company
        public ActionResult Index(int pageNo = 1, int dataSize = 10)
        {
            ViewBag.dataSize = dataSize;
            ViewBag.pageNo = pageNo;
            var companyProfileList = _companySocialProfileService.GetCompanySocialProfilePaged(new Page { PageNumber = pageNo, PageSize = dataSize });
            return View(companyProfileList);
        }

        #region Add Company Profile
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [RapidAuthorization]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanySocialProfile profile)
        {
            int companyId = 0;
            var company = _companyService.GetTopOneCompany();
            companyId = company != null ? company.Id : 0;
            profile.CompanyId = companyId;

            if (ModelState.IsValid)
            {
                if (_companySocialProfileService.AddCompanySocialProfile(profile))
                {
                    message.save(this);
                    return RedirectToAction("Index");
                }
            }
            return View(profile);
        }
        #endregion

        #region Update Company Profile
        [RapidAuthorization]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CompanySocialProfile profile = _companySocialProfileService.GetCompanyProfileDetails(id);
            if (profile == null)
            {
                return PartialView("_Error");
            }
            return View(profile);
        }

        [RapidAuthorization]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanySocialProfile profile)
        {
            if (ModelState.IsValid)
            {
                _companySocialProfileService.UpdateCompanySocialProfile(profile);
                message.update(this);
                return RedirectToAction("Index", new { page = TempData["page"] ?? 1, size = TempData["size"] ?? 10 });
            }
            return View(profile);
        }
        #endregion

        #region Delete
        [RapidAuthorization]
        public ActionResult Delete(int id)
        {
            if (_companySocialProfileService.DeleteCompanySocialProfile(id))
            {
                message.delete(this);
                return RedirectToAction("Index");
            }
            return PartialView("_Error");
        }
        #endregion
    }
}