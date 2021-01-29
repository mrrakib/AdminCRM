﻿using AdminCRM.Data.Infrastructure;
using AdminCRM.Filter;
using AdminCRM.Helper;
using AdminCRM.Model.Models.CompanyDetails;
using AdminCRM.Model.Models.Sections;
using AdminCRM.Model.ViewModels;
using AdminCRM.Service.Services.About;
using AdminCRM.Service.Services.BrandLogo;
using AdminCRM.Service.Services.CompanyServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminCRM.Controllers
{
    public class BrandsController : Controller
    {
        #region Global Variables
        private readonly IBrandService _brandService;
        private readonly Message message = new Message();
        private readonly string uploadFileName = "brand_";
        private readonly string subPath = "~/assets/Upload/BrandLogo";

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        #endregion
        // GET: Company
        public ActionResult Index(int pageNo = 1, int dataSize = 10)
        {
            ViewBag.dataSize = dataSize;
            ViewBag.pageNo = pageNo;
            var aboutSectionList = _brandService.GetPaged(new Page { PageNumber = pageNo, PageSize = dataSize });
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
        public ActionResult Create(Brands model)
        {
            if (ModelState.IsValid)
            {
                var imageUpDetails = UploadImage(Request);
                model.ImagePath = imageUpDetails.ImagePath;
                model.ImageName = imageUpDetails.ImageName;
                if (_brandService.Add(model))
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
            Brands model = _brandService.GetDetails(id);
            if (model == null)
            {
                return PartialView("_Error");
            }

            return View(model);
        }

        [RapidAuthorization]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brands model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var hasFile = Request.Files[0];
                    if (hasFile != null && hasFile.ContentLength > 0)
                    {
                        bool exists = Directory.Exists(Server.MapPath(subPath));
                        if (exists)
                        {
                            string imageName = String.IsNullOrEmpty(model.ImageName) ? "" : model.ImageName;
                            var filteredByFilename = Directory
                                    .GetFiles(Server.MapPath(subPath))
                                    .Select(f => Path.GetFileName(f))
                                    .Where(f => f.Equals(imageName));

                            if (filteredByFilename != null)
                            {
                                foreach (var filname in filteredByFilename)
                                {
                                    var path = Path.Combine(Server.MapPath(subPath), filname);
                                    if (System.IO.File.Exists(path))
                                    {
                                        System.IO.File.Delete(path);
                                    }
                                }

                            }
                        }
                        //delete previous file
                        var imageUpDetails = UploadImage(Request);
                        model.ImagePath = imageUpDetails.ImagePath;
                        model.ImageName = imageUpDetails.ImageName;
                    }
                    // model.ImagePath = subPath +"/" + uploadFileName;
                    
                }
                _brandService.Update(model);
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
            if (_brandService.Delete(id))
            {
                message.delete(this);
                return RedirectToAction("Index");
            }
            return PartialView("_Error");
        }
        #endregion

        #region Image Upload
        private VMImage UploadImage(HttpRequestBase httpRequest)
        {
            string filePath = "";
            string fileName = "";
            if (httpRequest.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    string fileExtension = Path.GetExtension(Request.Files["file"].FileName);
                    if (fileExtension == ".png" || fileExtension == ".jpg" || fileExtension == ".jpeg")
                    {
                        var fileExt = Path.GetExtension(file.FileName);
                        fileName = uploadFileName + Guid.NewGuid().ToString() + fileExt;

                        bool exists = Directory.Exists(Server.MapPath(subPath));
                        if (!exists)
                            Directory.CreateDirectory(Server.MapPath(subPath));

                        var path = Path.Combine(Server.MapPath(subPath), fileName);
                        file.SaveAs(path);
                        filePath = subPath + "/" + fileName;
                    }
                }
            }
            return new VMImage { ImageName = fileName, ImagePath = filePath };
        }
        #endregion
    }
}