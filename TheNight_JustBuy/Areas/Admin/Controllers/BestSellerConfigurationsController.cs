using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheNight_JustBuy.Common;
using TheNight_JustBuy.Models;

namespace TheNight_JustBuy.Areas.Admin.Controllers
{
    [Authorize(Roles = "true")]
    public class BestSellerConfigurationsController : BaseController
    {
        private JustBuyEntities db = new JustBuyEntities();

        // GET: Admin/BestSellerConfigurations
        public ActionResult Index()
        {
            return View(db.Configurations.Where(c => c.ConfigName.Contains("bestseller")).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Configuration configuration = db.Configurations.Find(id);
            if (configuration == null)
            {
                return HttpNotFound();
            }
            return View(configuration);
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Configuration configuration = db.Configurations.Find(id);
            Session.Add(CommonConstants.TEMP_CONFIGURATION_IMAGE, configuration.ImageFileName);
            if (configuration == null)
            {
                return HttpNotFound();
            }
            return View(configuration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConfigID,ConfigName,ImageFileName, ImageFile")] Configuration configuration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(configuration).State = EntityState.Modified;
                try
                {
                    if (configuration.ImageFile == null)
                    {
                        configuration.ImageFileName = Session[CommonConstants.TEMP_CONFIGURATION_IMAGE].ToString();
                    }
                    else
                    {
                        string fileName = Path.GetFileNameWithoutExtension(configuration.ImageFile.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(configuration.ImageFile.FileName);

                        configuration.ImageFileName = "~/public/uploadedFiles/configurationPictures/" + fileName;

                        string uploadFolderPath = Server.MapPath("~/public/uploadedFiles/configurationPictures/");

                        if (Directory.Exists(uploadFolderPath) == false)
                        {
                            Directory.CreateDirectory(uploadFolderPath);
                        }

                        fileName = Path.Combine(uploadFolderPath, fileName);

                        try
                        {
                            System.IO.File.Delete(Server.MapPath(Session[Common.CommonConstants.TEMP_CONFIGURATION_IMAGE].ToString()));
                        }
                        catch (Exception)
                        {
                        }
                        configuration.ImageFile.SaveAs(fileName);

                    }

                    if (db.SaveChanges() > 0)
                    {
                        Session.Remove(CommonConstants.TEMP_CONFIGURATION_IMAGE);
                        TempData.Add(CommonConstants.SAVE_SUCCESSFULLY, true);
                    }
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    TempData.Add(CommonConstants.SAVE_FAILED, true);
                    ex.Entries.Single().Reload();
                }

                return RedirectToAction("Index");
            }
            return View(configuration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

