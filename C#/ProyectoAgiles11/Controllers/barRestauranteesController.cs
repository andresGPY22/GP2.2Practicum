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
    public class barRestauranteesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: barRestaurantees
        public ActionResult Index()
        {
            string proveedorId = User.Identity.GetUserId();
            var proveedorBares = db.barRestaurantes.Where(b => b.UserId == proveedorId).ToList();
            return View(proveedorBares);
        }

        // GET: barRestaurantees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string proveedorId = User.Identity.GetUserId();
            barRestaurante barRestaurante = db.barRestaurantes.Find(id);
            if (barRestaurante == null || barRestaurante.UserId!= proveedorId)
            {
                return HttpNotFound();
            }
            return View(barRestaurante);
        }

        // GET: barRestaurantees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: barRestaurantees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "identificador,nombre,ciudad,provincia,comunidadAutonoma,pais,tipoComida,estilo,precioMin,precioMax,valoracionMedia,videoFoto")] barRestaurante barRestaurante)
        {
            string proveedorId = User.Identity.GetUserId();
            barRestaurante.UserId = proveedorId;
            if (ModelState.IsValid)
            {
                db.barRestaurantes.Add(barRestaurante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barRestaurante);
        }

        // GET: barRestaurantees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string proveedorId = User.Identity.GetUserId();
            barRestaurante barRestaurante = db.barRestaurantes.Find(id);
            if (barRestaurante == null || barRestaurante.UserId!= proveedorId)
            {
                return HttpNotFound();
            }
            return View(barRestaurante);
        }

        // POST: barRestaurantees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "identificador,nombre,ciudad,provincia,comunidadAutonoma,pais,tipoComida,estilo,precioMin,precioMax,valoracionMedia,videoFoto")] barRestaurante barRestaurante)
        {
            string proveedorId = User.Identity.GetUserId();
            barRestaurante.UserId = proveedorId;
            if (ModelState.IsValid)
            {
                db.Entry(barRestaurante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barRestaurante);
        }

        // GET: barRestaurantees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string proveedorId = User.Identity.GetUserId();
            barRestaurante barRestaurante = db.barRestaurantes.Find(id);
            if (barRestaurante == null || barRestaurante.UserId != proveedorId)
            {
                return HttpNotFound();
            }
            return View(barRestaurante);
        }

        // POST: barRestaurantees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            barRestaurante barRestaurante = db.barRestaurantes.Find(id);
            db.barRestaurantes.Remove(barRestaurante);
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
