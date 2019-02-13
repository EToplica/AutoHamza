using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoHamza.AccessLayer;
using AutoHamza.Models;
using AutoHamza.Models.Model;

namespace AutoHamza.Controllers
{
    public class VeturasController : Controller
    {
        private AutoHamzaContext db = new AutoHamzaContext();

        // GET: Veturas
        public ActionResult Index()
        {
            return View(db.Veturas.ToList());
        }

        // GET: Veturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vetura vetura = db.Veturas.Find(id);
            if (vetura == null)
            {
                return HttpNotFound();
            }
            return View(vetura);
        }

        // GET: Veturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VeturaID,Emri,IsActive")] Vetura vetura)
        {
            if (ModelState.IsValid)
            {
                //db.Veturas.Add(vetura);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateVetura(VeturaCreate vetura)
        {
            if (ModelState.IsValid)
            {
                DAL_Vetura.AddVetura(vetura);
            }

            return RedirectToAction("Index", "Brendis");
        }

        // GET: Veturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vetura vetura = db.Veturas.Find(id);
            if (vetura == null)
            {
                return HttpNotFound();
            }
            return View(vetura);
        }

        // POST: Veturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VeturaID,Emri,IsActive")] Vetura vetura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vetura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vetura);
        }

        // GET: Veturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vetura vetura = db.Veturas.Find(id);
            if (vetura == null)
            {
                return HttpNotFound();
            }
            return View(vetura);
        }

        // POST: Veturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vetura vetura = db.Veturas.Find(id);
            db.Veturas.Remove(vetura);
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
