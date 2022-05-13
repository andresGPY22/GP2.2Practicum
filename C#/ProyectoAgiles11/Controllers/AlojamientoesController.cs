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
    public class AlojamientoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Alojamientoes
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userProducts = db.Alojamientoes.Where(p => p.UserId == currentUserId).ToList();
            return View(userProducts);
        }

        // GET: Alojamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alojamiento alojamiento = db.Alojamientoes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (alojamiento == null || alojamiento.UserId != currentUserId)
            {
                return HttpNotFound();
            }
            return View(alojamiento);
        }

        // GET: Alojamientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alojamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlojamientoId,Nombre,CiudadPueblo,Provincia,ComunidadAutonoma,Pais,Tipo,Categoria,Descripcion,HayParking,HayPiscina,HayInstalacionesDeportivas,HayInstalacionesInfantiles,VideoFoto")] Alojamiento alojamiento)
        {
            string currentUserId = User.Identity.GetUserId();
            alojamiento.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Alojamientoes.Add(alojamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alojamiento);
        }

        // GET: Alojamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alojamiento alojamiento = db.Alojamientoes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (alojamiento == null || alojamiento.UserId != currentUserId)
            {
                return HttpNotFound();
            }
            return View(alojamiento);
        }

        // POST: Alojamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlojamientoId,Nombre,CiudadPueblo,Provincia,ComunidadAutonoma,Pais,Tipo,Categoria,Descripcion,HayParking,HayPiscina,HayInstalacionesDeportivas,HayInstalacionesInfantiles,VideoFoto")] Alojamiento alojamiento)
        {
            string currentUserId = User.Identity.GetUserId();
            alojamiento.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(alojamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alojamiento);
        }

        // GET: Alojamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alojamiento alojamiento = db.Alojamientoes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (alojamiento == null || alojamiento.UserId != currentUserId)
            {
                return HttpNotFound();
            }
            return View(alojamiento);
        }

        // POST: Alojamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alojamiento alojamiento = db.Alojamientoes.Find(id);
            db.Alojamientoes.Remove(alojamiento);
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
