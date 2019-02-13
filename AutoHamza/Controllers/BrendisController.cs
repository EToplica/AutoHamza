using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoHamza.AccessLayer;
using AutoHamza.Models;
using AutoHamza.Models.Model;
using AutoHamza.Models.ViewModel;

namespace AutoHamza.Controllers
{
    public class BrendisController : Controller
    {
        private AutoHamzaContext db = new AutoHamzaContext();

        // GET: Brendis
        public ActionResult Index()
        {
            var list = DAL_Brendet.GetAllBrendet();

            return View(list);
            //return View(db.Brendis.ToList());
        }

        // GET: Brendis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brendi brendi = db.Brendis.Find(id);
            if (brendi == null)
            {
                return HttpNotFound();
            }
            return View(brendi);
        }

        // GET: Brendis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brendis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrendiID,Emri,Foto,IsActive")] Brendi brendi, HttpPostedFileBase image)
        {
            string imagename = Path.GetFileName(image.FileName);
            string path = Server.MapPath("/Content/brendetimages/" + imagename);

            image.SaveAs(path);

            if (ModelState.IsValid)
            {
                // db.Brendis.Add(brendi);
                //db.SaveChanges();

                brendi.Foto = imagename;
                DAL_Brendet.AddBrand(brendi);

                return RedirectToAction("Index");
            }

            return View(brendi);
        }

        [HttpGet]
        public JsonResult GetAllVeturasByBrandID(int id)
        {
            var result = DAL_Vetura.GetAllVeturasByBrandID(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Veturat(int id)
        {
            List<VM_VeturaWithLlojet> listveturat;

            listveturat = DAL_Vetura.GetAllVeturasByBrandID(id);

            ViewBag.id = id;
            ViewBag.Brendi = DAL_Brendet.GetBrendByID(id);

            return View(listveturat);
        }

        // GET: Brendis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brendi brendi = db.Brendis.Find(id);
            if (brendi == null)
            {
                return HttpNotFound();
            }
            return View(brendi);
        }

        // POST: Brendis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrendiID,Emri,Foto,IsActive")] Brendi brendi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brendi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brendi);
        }

        // GET: Brendis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brendi brendi = db.Brendis.Find(id);
            if (brendi == null)
            {
                return HttpNotFound();
            }
            return View(brendi);
        }

        // POST: Brendis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brendi brendi = db.Brendis.Find(id);
            db.Brendis.Remove(brendi);
            db.SaveChanges();
            return RedirectToAction("Index");
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
