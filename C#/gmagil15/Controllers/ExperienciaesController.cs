using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portal.Models;
using Microsoft.AspNet.Identity;

namespace Portal.Controllers
{
    [Authorize]
    public class ExperienciaesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Experienciaes
        public ActionResult Index()
        {
            string currentUserID = User.Identity.GetUserId();
            var userProducts = db.Experiencias.Where(p => p.UserId == currentUserID).ToList();
            return View(userProducts);
        }

        // GET: Experienciaes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = db.Experiencias.Find(id);
            string currentUserID = User.Identity.GetUserId();
            if (experiencia.UserId != currentUserID || experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // GET: Experienciaes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experienciaes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "experienciaId,Tipo,agenciaPatrocinadora,Ciudad,Lugar,Dias,FechaIni,FechaFin,Hora,Duracion,PrecioMin,PrecioMed,PrecioMax,DescripcionPrecios,Excepciones")] Experiencia experiencia)
        {
            string currentUserID = User.Identity.GetUserId();
            experiencia.UserId = currentUserID;

            if (ModelState.IsValid)
            {
                db.Experiencias.Add(experiencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(experiencia);
        }

        // GET: Experienciaes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = db.Experiencias.Find(id);
            string currentUserID = User.Identity.GetUserId();
            if (experiencia.UserId != currentUserID || experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // POST: Experienciaes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "experienciaId,Tipo,agenciaPatrocinadora,Ciudad,Lugar,Dias,FechaIni,FechaFin,Hora,Duracion,PrecioMin,PrecioMed,PrecioMax,DescripcionPrecios,Excepciones")] Experiencia experiencia)
        {
            string currentUserID = User.Identity.GetUserId();
            experiencia.UserId = currentUserID;

            if (ModelState.IsValid)
            {
                db.Entry(experiencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(experiencia);
        }

        // GET: Experienciaes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = db.Experiencias.Find(id);
            string currentUserID = User.Identity.GetUserId();
            if (experiencia.UserId != currentUserID || experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // POST: Experienciaes/Delete/5
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
