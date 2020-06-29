using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NearCollegeFINAL.Models;

namespace NearCollegeFINAL.Controllers
{
    public class Tbl_GradosController : Controller
    {
        private NearCollegeEntities db = new NearCollegeEntities();

        // GET: Tbl_Grados
        public ActionResult Index()
        {
            return View(db.Tbl_Grados.ToList());
        }

        // GET: Tbl_Grados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Grados tbl_Grados = db.Tbl_Grados.Find(id);
            if (tbl_Grados == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Grados);
        }

        // GET: Tbl_Grados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Grados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGrado,NombreGrado,JornadaGrado,DisponibilidadCupoGrado")] Tbl_Grados tbl_Grados)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Grados.Add(tbl_Grados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Grados);
        }

        // GET: Tbl_Grados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Grados tbl_Grados = db.Tbl_Grados.Find(id);
            if (tbl_Grados == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Grados);
        }

        // POST: Tbl_Grados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGrado,NombreGrado,JornadaGrado,DisponibilidadCupoGrado")] Tbl_Grados tbl_Grados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Grados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Grados);
        }

        // GET: Tbl_Grados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Grados tbl_Grados = db.Tbl_Grados.Find(id);
            if (tbl_Grados == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Grados);
        }

        // POST: Tbl_Grados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Grados tbl_Grados = db.Tbl_Grados.Find(id);
            db.Tbl_Grados.Remove(tbl_Grados);
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
