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
    public class LocalesDeOcioNocturnoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LocalesDeOcioNocturnoes
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userProducts = db.LocalesDeOcioNocturnoes.Where(p => p.UserId == currentUserId).ToList();
            return View(userProducts);
        }

        // GET: LocalesDeOcioNocturnoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalesDeOcioNocturno localesDeOcioNocturno = db.LocalesDeOcioNocturnoes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if(localesDeOcioNocturno == null || localesDeOcioNocturno.UserId != currentUserId)
            {
                return HttpNotFound();
            }
            return View(localesDeOcioNocturno);
        }

        // GET: LocalesDeOcioNocturnoes/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: LocalesDeOcioNocturnoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,ciudadPueblo,provincia,comunidadAutonoma,pais,tipo,precioEntrada,valoracionMedia,videoFoto")] LocalesDeOcioNocturno localesDeOcioNocturno)
        {
            string currentUserId = User.Identity.GetUserId();
            localesDeOcioNocturno.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.LocalesDeOcioNocturnoes.Add(localesDeOcioNocturno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(localesDeOcioNocturno);
        }

        // GET: LocalesDeOcioNocturnoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalesDeOcioNocturno localesDeOcioNocturno = db.LocalesDeOcioNocturnoes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (localesDeOcioNocturno == null || localesDeOcioNocturno.UserId != currentUserId)
            {
                return HttpNotFound();
            }
            return View(localesDeOcioNocturno);
        }

        // POST: LocalesDeOcioNocturnoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,ciudadPueblo,provincia,comunidadAutonoma,pais,tipo,precioEntrada,valoracionMedia,videoFoto")] LocalesDeOcioNocturno localesDeOcioNocturno)
        {
            string currentUserId = User.Identity.GetUserId();
            localesDeOcioNocturno.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(localesDeOcioNocturno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(localesDeOcioNocturno);
        }

        // GET: LocalesDeOcioNocturnoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalesDeOcioNocturno localesDeOcioNocturno = db.LocalesDeOcioNocturnoes.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (localesDeOcioNocturno == null || localesDeOcioNocturno.UserId != currentUserId)
            {
                return HttpNotFound();
            }
            return View(localesDeOcioNocturno);
        }

        // POST: LocalesDeOcioNocturnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocalesDeOcioNocturno localesDeOcioNocturno = db.LocalesDeOcioNocturnoes.Find(id);
            db.LocalesDeOcioNocturnoes.Remove(localesDeOcioNocturno);
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
