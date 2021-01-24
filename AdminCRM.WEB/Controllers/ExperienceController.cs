using AdminCRM.Data.Infrastructure;
using AdminCRM.Filter;
using AdminCRM.Helper;
using AdminCRM.Model.Models.CompanyDetails;
using AdminCRM.Model.Models.Sections;
using AdminCRM.Service.Services.About;
using AdminCRM.Service.Services.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminCRM.Controllers
{
    public class ExperienceController : Controller
    {
        #region Global Variables
        private readonly IExperienceSectionService _experienceSectionService;
        private readonly Message message = new Message();

        public ExperienceController(IExperienceSectionService experienceSectionService)
        {
            _experienceSectionService = experienceSectionService;
        }
        #endregion
        // GET: Company
        public ActionResult Index(int pageNo = 1, int dataSize = 10)
        {
            ViewBag.dataSize = dataSize;
            ViewBag.pageNo = pageNo;
            var experienceSectionList = _experienceSectionService.GetExperiencePaged(new Page { PageNumber = pageNo, PageSize = dataSize });
            return View(experienceSectionList);
        }

        #region Add Experience
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [RapidAuthorization]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExperienceSection model)
        {
            if (ModelState.IsValid)
            {
                if (_experienceSectionService.AddExperienceSection(model))
                {
                    message.save(this);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        #endregion

        #region Update Experience
        [RapidAuthorization]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ExperienceSection model = _experienceSectionService.GetExperienceDetails(id);
            if (model == null)
            {
                return PartialView("_Error");
            }
            return View(model);
        }

        [RapidAuthorization]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExperienceSection model)
        {
            if (ModelState.IsValid)
            {
                _experienceSectionService.UpdateExperienceSection(model);
                message.update(this);
                return RedirectToAction("Index", new { page = TempData["page"] ?? 1, size = TempData["size"] ?? 10 });
            }
            return View(model);
        }
        #endregion

        #region Delete
        [RapidAuthorization]
        public ActionResult Delete(int id)
        {
            if (_experienceSectionService.DeleteExperienceSection(id))
            {
                message.delete(this);
                return RedirectToAction("Index");
            }
            return PartialView("_Error");
        }
        #endregion
    }
}