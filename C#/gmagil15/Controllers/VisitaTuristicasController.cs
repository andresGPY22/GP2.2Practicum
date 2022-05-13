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
    public class VisitaTuristicasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VisitaTuristicas
        public ActionResult Index()
        {
            string currentUserID = User.Identity.GetUserId();
            var userProducts = db.VisitaTuristicas.Where(p => p.UserId == currentUserID).ToList();
            return View(userProducts);
        }

        // GET: VisitaTuristicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitaTuristica visitaTuristica = db.VisitaTuristicas.Find(id);
            string currentUserID = User.Identity.GetUserId();
            if (visitaTuristica.UserId != currentUserID  || visitaTuristica == null)
            {
                return HttpNotFound();
            }
            return View(visitaTuristica);
        }

        // GET: VisitaTuristicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisitaTuristicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VisitaTuristicaId,Ciudad,Recorrido,Pago,Agencia,Tipo,FechaInicio,FechaFin,Hora,Duracion,Precio,DiasSemana,Excepciones")] VisitaTuristica visitaTuristica)
        {
            string currentUserId = User.Identity.GetUserId();
            visitaTuristica.UserId = currentUserId;
                if (ModelState.IsValid)
            {
                db.VisitaTuristicas.Add(visitaTuristica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visitaTuristica);
        }

        // GET: VisitaTuristicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitaTuristica visitaTuristica = db.VisitaTuristicas.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (visitaTuristica.UserId != currentUserId || visitaTuristica == null)
            {
                return HttpNotFound();
            }
            return View(visitaTuristica);
        }

        // POST: VisitaTuristicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisitaTuristicaId,Ciudad,Recorrido,Pago,Agencia,Tipo,FechaInicio,FechaFin,Hora,Duracion,Precio,DiasSemana,Excepciones")] VisitaTuristica visitaTuristica)
        {
            string currentUserId = User.Identity.GetUserId();
            visitaTuristica.UserId = currentUserId;
            if (ModelState.IsValid){
                db.Entry(visitaTuristica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visitaTuristica);
        }

        // GET: VisitaTuristicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitaTuristica visitaTuristica = db.VisitaTuristicas.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (visitaTuristica.UserId != currentUserId || visitaTuristica == null)
            {
                return HttpNotFound();
            }
            return View(visitaTuristica);
        }

        // POST: VisitaTuristicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitaTuristica visitaTuristica = db.VisitaTuristicas.Find(id);
            db.VisitaTuristicas.Remove(visitaTuristica);
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
