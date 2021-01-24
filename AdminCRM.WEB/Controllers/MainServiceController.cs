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
    public class MainServiceController : Controller
    {
        #region Global Variables
        private readonly IOurServiceMainService _ourServiceMainService;
        private readonly Message message = new Message();

        public MainServiceController(IOurServiceMainService ourServiceMainService)
        {
            _ourServiceMainService = ourServiceMainService;
        }
        #endregion
        // GET: Company
        public ActionResult Index(int pageNo = 1, int dataSize = 10)
        {
            ViewBag.dataSize = dataSize;
            ViewBag.pageNo = pageNo;
            var aboutSectionList = _ourServiceMainService.GetPaged(new Page { PageNumber = pageNo, PageSize = dataSize });
            return View(aboutSectionList);
        }

        #region Add
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [RapidAuthorization]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OurServiceMain model)
        {
            if (ModelState.IsValid)
            {
                if (_ourServiceMainService.Add(model))
                {
                    message.save(this);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        #endregion

        #region Update
        [RapidAuthorization]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            OurServiceMain model = _ourServiceMainService.GetDetails(id);
            if (model == null)
            {
                return PartialView("_Error");
            }
            return View(model);
        }

        [RapidAuthorization]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OurServiceMain model)
        {
            if (ModelState.IsValid)
            {
                _ourServiceMainService.Update(model);
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
            if (_ourServiceMainService.Delete(id))
            {
                message.delete(this);
                return RedirectToAction("Index");
            }
            return PartialView("_Error");
        }
        #endregion
    }
}