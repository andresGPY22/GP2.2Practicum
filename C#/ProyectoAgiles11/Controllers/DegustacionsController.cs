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
    public class DegustacionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Degustacions
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userProducts = db.Degustacions.Where(p => p.UserId == currentUserId).ToList();
            return View(userProducts);
        }

        // GET: Degustacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degustacion degustacion = db.Degustacions.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if(degustacion == null || degustacion.UserId != currentUserId)
            {
                return HttpNotFound();
            }
            return View(degustacion);
        }

        // GET: Degustacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Degustacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DegustacionId,Tipo,Lugar,Localidad,Provincia,ComunidadAutonoma,Pais,Precio,Duracion,VideoFoto,Obsequio")] Degustacion degustacion)
        {
            string currentUserId = User.Identity.GetUserId();
            degustacion.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Degustacions.Add(degustacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(degustacion);
        }

        // GET: Degustacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degustacion degustacion = db.Degustacions.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (degustacion == null || degustacion.UserId != currentUserId)
            {
                return HttpNotFound();
            }
            return View(degustacion);
        }

        // POST: Degustacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DegustacionId,Tipo,Lugar,Localidad,Provincia,ComunidadAutonoma,Pais,Precio,Duracion,VideoFoto,Obsequio")] Degustacion degustacion)
        {
            string currentUserId = User.Identity.GetUserId();
            degustacion.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(degustacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(degustacion);
        }

        // GET: Degustacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degustacion degustacion = db.Degustacions.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (degustacion == null || degustacion.UserId != currentUserId)
            {
                return HttpNotFound();
            }
            return View(degustacion);
        }

        // POST: Degustacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Degustacion degustacion = db.Degustacions.Find(id);
            db.Degustacions.Remove(degustacion);
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
