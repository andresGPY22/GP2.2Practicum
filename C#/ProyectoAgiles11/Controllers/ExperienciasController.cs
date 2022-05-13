using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeleViajes.Models;
using Microsoft.AspNet.Identity;

namespace TeleViajes.Controllers
{
    [Authorize]
    public class ExperienciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Experiencias
        public ActionResult Index()
        {
            string proveedorId = User.Identity.GetUserId();
            var proveedorExperiencias = db.Experiencias.Where(e => e.UserId == proveedorId).ToList();
            return View(proveedorExperiencias);
        }

        // GET: Experiencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string proveedorId = User.Identity.GetUserId();
            Experiencia experiencia = db.Experiencias.Find(id);
            if (experiencia == null || experiencia.UserId != proveedorId)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // GET: Experiencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experiencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExperienciaId,Tipo,Lugar,Localidad,Provincia,ComunidadAutonoma,Pais,Agencia,Precio,DiasDisponible,VideoFoto")] Experiencia experiencia)
        {
            string proveedorId = User.Identity.GetUserId();
            experiencia.UserId = proveedorId;
            if (ModelState.IsValid)
            {
                db.Experiencias.Add(experiencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(experiencia);
        }

        // GET: Experiencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = db.Experiencias.Find(id);
            string proveedorId = User.Identity.GetUserId();
            if (experiencia == null || experiencia.UserId != proveedorId)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // POST: Experiencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExperienciaId,Tipo,Lugar,Localidad,Provincia,ComunidadAutonoma,Pais,Agencia,Precio,DiasDisponible,VideoFoto")] Experiencia experiencia)
        {
            string proveedorId = User.Identity.GetUserId();
            experiencia.UserId = proveedorId;
            if (ModelState.IsValid)
            {
                db.Entry(experiencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(experiencia);
        }

        // GET: Experiencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = db.Experiencias.Find(id);
            string proveedorId = User.Identity.GetUserId();
            if (experiencia == null || experiencia.UserId != proveedorId)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // POST: Experiencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Experiencia experiencia = db.Experiencias.Find(id);
            db.Experiencias.Remove(experiencia);
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
