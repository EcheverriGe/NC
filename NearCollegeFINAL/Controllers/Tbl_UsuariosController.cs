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
    public class Tbl_UsuariosController : Controller
    {
        private NearCollegeEntities db = new NearCollegeEntities();

        // GET: Tbl_Usuarios
        public ActionResult Index()
        {
            var tbl_Usuarios = db.Tbl_Usuarios.Include(t => t.Tbl_Roles);
            return View(tbl_Usuarios.ToList());
        }

        // GET: Tbl_Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuarios tbl_Usuarios = db.Tbl_Usuarios.Find(id);
            if (tbl_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Usuarios);
        }

        // GET: Tbl_Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdRol = new SelectList(db.Tbl_Roles, "IdRol", "NombreRol");
            return View();
        }

        // POST: Tbl_Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,NombreUsuario,ApellidoUsuario,CorreoUsuario,ContraseñaUsuario,IdRol")] Tbl_Usuarios tbl_Usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Usuarios.Add(tbl_Usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRol = new SelectList(db.Tbl_Roles, "IdRol", "NombreRol", tbl_Usuarios.IdRol);
            return View(tbl_Usuarios);
        }

        // GET: Tbl_Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuarios tbl_Usuarios = db.Tbl_Usuarios.Find(id);
            if (tbl_Usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRol = new SelectList(db.Tbl_Roles, "IdRol", "NombreRol", tbl_Usuarios.IdRol);
            return View(tbl_Usuarios);
        }

        // POST: Tbl_Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,NombreUsuario,ApellidoUsuario,CorreoUsuario,ContraseñaUsuario,IdRol")] Tbl_Usuarios tbl_Usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRol = new SelectList(db.Tbl_Roles, "IdRol", "NombreRol", tbl_Usuarios.IdRol);
            return View(tbl_Usuarios);
        }

        // GET: Tbl_Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuarios tbl_Usuarios = db.Tbl_Usuarios.Find(id);
            if (tbl_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Usuarios);
        }

        // POST: Tbl_Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Usuarios tbl_Usuarios = db.Tbl_Usuarios.Find(id);
            db.Tbl_Usuarios.Remove(tbl_Usuarios);
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
