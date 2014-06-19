using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplicacioOptativa.Models;

namespace AplicacioOptativa.Controllers
{
    public class AutosController : Controller
    {
        private AplicacioOptativaContext db = new AplicacioOptativaContext();

        //
        // GET: /Autos/

        public ActionResult Index()
        {
            return View(db.Autos.ToList());
        }

        //
        // GET: /Autos/Details/5

        public ActionResult Details(int id = 0)
        {
            Autos autos = db.Autos.Find(id);
            if (autos == null)
            {
                return HttpNotFound();
            }
            return View(autos);
        }

        //
        // GET: /Autos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Autos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autos autos)
        {
            if (ModelState.IsValid)
            {
                db.Autos.Add(autos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autos);
        }

        //
        // GET: /Autos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Autos autos = db.Autos.Find(id);
            if (autos == null)
            {
                return HttpNotFound();
            }
            return View(autos);
        }

        //
        // POST: /Autos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Autos autos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autos);
        }

        //
        // GET: /Autos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Autos autos = db.Autos.Find(id);
            if (autos == null)
            {
                return HttpNotFound();
            }
            return View(autos);
        }

        //
        // POST: /Autos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autos autos = db.Autos.Find(id);
            db.Autos.Remove(autos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}