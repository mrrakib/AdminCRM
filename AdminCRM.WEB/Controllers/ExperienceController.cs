using AdminCRM.Data.Infrastructure;
using AdminCRM.Filter;
using AdminCRM.Helper;
using AdminCRM.Model.Models.CompanyDetails;
using AdminCRM.Model.Models.Sections;
using AdminCRM.Service.Services.About;
using AdminCRM.Service.Services.CompanyServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminCRM.Controllers
{
    public class ExperienceController : Controller
    {
        #region Global Variables
        private readonly IExperienceSectionService _experienceSectionService;
        private readonly string uploadFileName = "";
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
                model.ImagePath = UploadImage(Request);
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
                if (Request.Files.Count > 0)
                {
                    string subPath = "~/assets/Upload/Experience";
                    var hasFile = Request.Files[0];
                    if (hasFile != null && hasFile.ContentLength > 0)
                    {
                        bool exists = Directory.Exists(Server.MapPath(subPath));
                        if (exists)
                        {
                            var filteredByFilename = Directory
                                    .GetFiles(Server.MapPath("~/assets/Upload/Experience"))
                                    .Select(f => Path.GetFileName(f))
                                    .Where(f => f.StartsWith(uploadFileName));

                            if (filteredByFilename != null)
                            {
                                foreach (var filname in filteredByFilename)
                                {
                                    var path = Path.Combine(Server.MapPath("~/assets/Upload/Experience"), filname);
                                    if (System.IO.File.Exists(path))
                                    {
                                        System.IO.File.Delete(path);
                                    }
                                }

                            }
                        }
                        //delete previous file

                    }
                    // model.ImagePath = subPath +"/" + uploadFileName;

                    model.ImagePath = UploadImage(Request);
                }
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

        #region Image Upload
        private string UploadImage(HttpRequestBase httpRequest)
        {
            string filePath = "";
            if (httpRequest.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);
                    if (fileExtension == ".png" || fileExtension == ".jpg" || fileExtension == ".jpeg")
                    {
                        var fileExt = Path.GetExtension(file.FileName);
                        string fileName = uploadFileName + fileExt;
                        //FileDetail fileDetail = new FileDetail()
                        //{
                        //    FileName = Path.GetFileNameWithoutExtension(fileName),
                        //    Extension = Path.GetExtension(fileName),
                        //    Id = Guid.NewGuid()
                        //};
                        string subPath = "~/assets/Upload/Experience";
                        bool exists = Directory.Exists(Server.MapPath(subPath));
                        if (!exists)
                            Directory.CreateDirectory(Server.MapPath(subPath));

                        var path = Path.Combine(Server.MapPath("~/assets/Upload/Experience"), uploadFileName + fileExt);
                        file.SaveAs(path);
                        filePath = subPath + "/" + uploadFileName + fileExt;
                    }
                }
            }
            return filePath;
        }
        #endregion
    }
}