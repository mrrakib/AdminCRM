using AdminCRM.Data.Infrastructure;
using AdminCRM.Filter;
using AdminCRM.Helper;
using AdminCRM.Model.Models.CompanyDetails;
using AdminCRM.Model.Models.Sections;
using AdminCRM.Service.Services.About;
using AdminCRM.Service.Services.CompanyServices;
using AdminCRM.Service.Services.Contact;
using AdminCRM.Service.Services.Feature;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminCRM.Controllers
{
    public class ContactUsController : Controller
    {
        #region Global Variables
        private readonly IContactUsService _contactUsService;
        private readonly Message message = new Message();

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        #endregion
        // GET: Company
        public ActionResult Index(int pageNo = 1, int dataSize = 10)
        {
            ViewBag.dataSize = dataSize;
            ViewBag.pageNo = pageNo;
            var aboutSectionList = _contactUsService.GetPaged(new Page { PageNumber = pageNo, PageSize = dataSize });
            return View(aboutSectionList);
        }

        #region Add About
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [RapidAuthorization]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactUs model)
        {
            if (ModelState.IsValid)
            {
                if (_contactUsService.Add(model))
                {
                    message.save(this);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        #endregion

        #region Update Company Profile
        [RapidAuthorization]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ContactUs model = _contactUsService.GetDetails(id);
            if (model == null)
            {
                return PartialView("_Error");
            }

            return View(model);
        }

        [RapidAuthorization]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactUs model)
        {
            if (ModelState.IsValid)
            {
                _contactUsService.Update(model);
                message.update(this);
                return RedirectToAction("Index", new { page = TempData["page"] ?? 1, size = TempData["size"] ?? 10 });

                //upload new file if have
            }//end upload new file

            return View(model);
        }
        #endregion

        #region Delete
        [RapidAuthorization]
        public ActionResult Delete(int id)
        {
            if (_contactUsService.Delete(id))
            {
                message.delete(this);
                return RedirectToAction("Index");
            }
            return PartialView("_Error");
        }
        #endregion
    }
}