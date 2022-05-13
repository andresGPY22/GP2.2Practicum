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
    public class EncuentroDeportivoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EncuentroDeportivoes
        public ActionResult Index()
        {
            string currentUserID = User.Identity.GetUserId();
            var userProducts = db.EncuentroDeportivoes.Where(p => p.UserId == currentUserID).ToList();
            return View(userProducts);
        }

        // GET: EncuentroDeportivoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncuentroDeportivo encuentroDeportivo = db.EncuentroDeportivoes.Find(id);
            string currentUserID = User.Identity.GetUserId();
            if (encuentroDeportivo.UserId != currentUserID || encuentroDeportivo == null)
            {
                return HttpNotFound();
            }
            return View(encuentroDeportivo);
        }
        // GET: EncuentroDeportivoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EncuentroDeportivoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEncuentroDeportivo,Deporte,EquipoLocal,EquipoVisitante,Ciudad,Lugar,Dia,Hora,PrecioMin,PrecioMed,PrecioMax")] EncuentroDeportivo encuentroDeportivo)
        {
            string currentUserID = User.Identity.GetUserId();
            encuentroDeportivo.UserId = currentUserID;
                if (ModelState.IsValid)
            {
                db.EncuentroDeportivoes.Add(encuentroDeportivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(encuentroDeportivo);
        }

        // GET: EncuentroDeportivoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncuentroDeportivo encuentroDeportivo = db.EncuentroDeportivoes.Find(id);
            string currentUserID = User.Identity.GetUserId();
            if (encuentroDeportivo.UserId != currentUserID || encuentroDeportivo == null)
            {
                return HttpNotFound();
            }
            return View(encuentroDeportivo);
        }

        // POST: EncuentroDeportivoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEncuentroDeportivo,Deporte,EquipoLocal,EquipoVisitante,Ciudad,Lugar,Dia,Hora,PrecioMin,PrecioMed,PrecioMax")] EncuentroDeportivo encuentroDeportivo)
        {
            string currentUserId = User.Identity.GetUserId();
            encuentroDeportivo.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(encuentroDeportivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(encuentroDeportivo);
        }

        // GET: EncuentroDeportivoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncuentroDeportivo encuentroDeportivo = db.EncuentroDeportivoes.Find(id);
            string currentUserID = User.Identity.GetUserId();
            if (encuentroDeportivo.UserId != currentUserID || encuentroDeportivo == null)
            {
                return HttpNotFound();
            }
            return View(encuentroDeportivo);
        }

        // POST: EncuentroDeportivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EncuentroDeportivo encuentroDeportivo = db.EncuentroDeportivoes.Find(id);
            db.EncuentroDeportivoes.Remove(encuentroDeportivo);
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
