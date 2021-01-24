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
    public class CompanyController : Controller
    {
        #region Global Variables
        private readonly ICompanyService _companyService;
        private readonly Message message = new Message();

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        #endregion
        // GET: Company
        public ActionResult Index(int pageNo = 1, int dataSize = 10)
        {
            ViewBag.dataSize = dataSize;
            ViewBag.pageNo = pageNo;
            var companyList = _companyService.GetCompanyPaged(new Page { PageNumber = pageNo, PageSize = dataSize });
            return View(companyList);
        }

        #region Add Company
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [RapidAuthorization]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                if (_companyService.AddCompany(company))
                {
                    message.save(this);
                    return RedirectToAction("Index");
                }
            }
            return View(company);
        }
        #endregion

        #region Update Company
        [RapidAuthorization]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Company company = _companyService.GetCompanyDetails(id);
            if (company == null)
            {
                return PartialView("_Error");
            }
            return View(company);
        }

        [RapidAuthorization]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                _companyService.UpdateCompany(company);
                message.update(this);
                return RedirectToAction("Index", new { page = TempData["page"] ?? 1, size = TempData["size"] ?? 10 });
            }
            return View(company);
        }
        #endregion
    }
}