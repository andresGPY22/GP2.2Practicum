using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portal.Models;

namespace Portal.Controllers
{
    [AllowAnonymous]
    public class PortalComentariosesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PortalComentarioses
        public ActionResult Index()
        {
            return View(db.PortalComentarios.ToList());
        }

        // GET: PortalComentarioses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortalComentarios portalComentarios = db.PortalComentarios.Find(id);
            if (portalComentarios == null)
            {
                return HttpNotFound();
            }
            return View(portalComentarios);
        }

        // GET: PortalComentarioses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortalComentarioses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioId,Usuario,Evento,Comentario")] PortalComentarios portalComentarios)
        {
            if (ModelState.IsValid)
            {
                db.PortalComentarios.Add(portalComentarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portalComentarios);
        }

        // GET: PortalComentarioses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortalComentarios portalComentarios = db.PortalComentarios.Find(id);
            if (portalComentarios == null)
            {
                return HttpNotFound();
            }
            return View(portalComentarios);
        }

        // POST: PortalComentarioses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioId,Usuario,Evento,Comentario")] PortalComentarios portalComentarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portalComentarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portalComentarios);
        }

        // GET: PortalComentarioses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortalComentarios portalComentarios = db.PortalComentarios.Find(id);
            if (portalComentarios == null)
            {
                return HttpNotFound();
            }
            return View(portalComentarios);
        }

        // POST: PortalComentarioses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PortalComentarios portalComentarios = db.PortalComentarios.Find(id);
            db.PortalComentarios.Remove(portalComentarios);
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
