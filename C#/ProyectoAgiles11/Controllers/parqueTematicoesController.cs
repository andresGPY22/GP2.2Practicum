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
    public class parqueTematicoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: parqueTematicoes
        public ActionResult Index()
        {
            string proveedorId = User.Identity.GetUserId();
            var proveedorParques = db.parqueTematicoes.Where(p=>p.UserId==proveedorId).ToList();
            return View(proveedorParques);
        }

        // GET: parqueTematicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var proveedorId = User.Identity.GetUserId();
            parqueTematico parqueTematico = db.parqueTematicoes.Find(id);
            if (parqueTematico == null || parqueTematico.UserId!= proveedorId)
            {
                return HttpNotFound();
            }
            return View(parqueTematico);
        }

        // GET: parqueTematicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: parqueTematicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,ciudadPueblo,provincia,comunidadAutonoma,pais,tipo,precioMin,precioMax,videoFoto")] parqueTematico parqueTematico)
        {
            string proveedorId = User.Identity.GetUserId();
            parqueTematico.UserId = proveedorId;
            if (ModelState.IsValid)
            {
                db.parqueTematicoes.Add(parqueTematico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parqueTematico);
        }

        // GET: parqueTematicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string proveedorId = User.Identity.GetUserId();
            parqueTematico parqueTematico = db.parqueTematicoes.Find(id);
            if (parqueTematico == null || parqueTematico.UserId != proveedorId)
            {
                return HttpNotFound();
            }
            return View(parqueTematico);
        }

        // POST: parqueTematicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,ciudadPueblo,provincia,comunidadAutonoma,pais,tipo,precioMin,precioMax,videoFoto")] parqueTematico parqueTematico)
        {
            string proveedorId = User.Identity.GetUserId();
            parqueTematico.UserId = proveedorId;
            if (ModelState.IsValid)
            {
                db.Entry(parqueTematico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parqueTematico);
        }

        // GET: parqueTematicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            string proveedorId = User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parqueTematico parqueTematico = db.parqueTematicoes.Find(id);
            if (parqueTematico == null || parqueTematico.UserId != proveedorId)
            {
                return HttpNotFound();
            }
            return View(parqueTematico);
        }

        // POST: parqueTematicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            parqueTematico parqueTematico = db.parqueTematicoes.Find(id);
            db.parqueTematicoes.Remove(parqueTematico);
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
