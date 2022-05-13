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
    public class MuseosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Museos
        public ActionResult Index()
        {
            string currentUserID = User.Identity.GetUserId();
            var userProducts = db.Museos.Where(p => p.UserId == currentUserID).ToList();
            return View(userProducts);
        }

        // GET: Museos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museo museo = db.Museos.Find(id);
            string currentUserID = User.Identity.GetUserId();
            if (museo.UserId != currentUserID || museo == null)
            {
                return HttpNotFound();
            }
            return View(museo);
        }

        // GET: Museos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Museos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "museoId,nombre,Dias,obrasDestacadas,Precio")] Museo museo)
        {
            string currentUserID = User.Identity.GetUserId();
            museo.UserId = currentUserID;

            if (ModelState.IsValid)
            {
                db.Museos.Add(museo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(museo);
        }

        // GET: Museos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museo museo = db.Museos.Find(id);
            string currentUserID = User.Identity.GetUserId();
            if (museo.UserId != currentUserID || museo == null)
            {
                return HttpNotFound();
            }
            return View(museo);
        }

        // POST: Museos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "museoId,nombre,Dias,obrasDestacadas,Precio")] Museo museo)
        {
            string currentUserID = User.Identity.GetUserId();
            museo.UserId = currentUserID;

            if (ModelState.IsValid)
            {
                db.Entry(museo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(museo);
        }

        // GET: Museos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museo museo = db.Museos.Find(id);
            string currentUserID = User.Identity.GetUserId();
            if (museo.UserId != currentUserID || museo == null)
            {
                return HttpNotFound();
            }
            return View(museo);
        }

        // POST: Museos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Museo museo = db.Museos.Find(id);
            db.Museos.Remove(museo);
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
