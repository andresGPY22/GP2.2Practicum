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
    public class EspectaculoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Espectaculoes
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userEspectaculo = db.Espectaculoes.Where(p => p.UserId == currentUserId).ToList();
            return View(userEspectaculo);
        }

        // GET: Espectaculoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Espectaculo espectaculo = db.Espectaculoes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (espectaculo == null || espectaculo.UserId != currentUserId)
            {
                return HttpNotFound();
            }
            return View(espectaculo);
        }

        // GET: Espectaculoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Espectaculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EspectaculoID,Titulo,Tipo,Lugar,CiudadPueblo,Provincia,ComunidadAutonoma,Pais,DuracionMinutos,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo,FechaInicial,FechaFinal,PrecioMinimo,PrecioMaximo,VideoFoto")] Espectaculo espectaculo)
        {
            string currentUserId = User.Identity.GetUserId();
            espectaculo.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Espectaculoes.Add(espectaculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(espectaculo);
        }

        // GET: Espectaculoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Espectaculo espectaculo = db.Espectaculoes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (espectaculo == null || espectaculo.UserId != currentUserId)
            {
                return HttpNotFound();
            }
            return View(espectaculo);
        }

        // POST: Espectaculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EspectaculoID,Titulo,Tipo,Lugar,CiudadPueblo,Provincia,ComunidadAutonoma,Pais,DuracionMinutos,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo,FechaInicial,FechaFinal,PrecioMinimo,PrecioMaximo,VideoFoto")] Espectaculo espectaculo)
        {
            string currentUserId = User.Identity.GetUserId();
            espectaculo.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(espectaculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(espectaculo);
        }

        // GET: Espectaculoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Espectaculo espectaculo = db.Espectaculoes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (espectaculo == null || espectaculo.UserId != currentUserId)
            {
                return HttpNotFound();
            }
            return View(espectaculo);
        }

        // POST: Espectaculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Espectaculo espectaculo = db.Espectaculoes.Find(id);
            db.Espectaculoes.Remove(espectaculo);
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
