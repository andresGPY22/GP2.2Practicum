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
    public class ObraDeTeatroesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ObraDeTeatroes


        public ActionResult Index()
        {
            string currentUserID = User.Identity.GetUserId();
            var userProducts = db.ObraDeTeatroes.Where(p => p.UserId == currentUserID).ToList();
            return View(userProducts);
        }



        // GET: ObraDeTeatroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObraDeTeatro obraDeTeatro = db.ObraDeTeatroes.Find(id);
            string currentUserID = User.Identity.GetUserId();
            if (obraDeTeatro.UserId != currentUserID || obraDeTeatro == null)
            {
                return HttpNotFound();
            }
            return View(obraDeTeatro);
        }

        // GET: ObraDeTeatroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ObraDeTeatroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "obraTeatroId,Titulo,ActoresPrincipales,Ciudad,Lugar,Dias,FechaIni,FechaFin,Hora,Duracion,PrecioMin,PrecioMed,PrecioMax,DescripcionPrecios")] ObraDeTeatro obraDeTeatro)
        {
            string currentUserID = User.Identity.GetUserId();
            obraDeTeatro.UserId = currentUserID;

            if (ModelState.IsValid)
            {
                db.ObraDeTeatroes.Add(obraDeTeatro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obraDeTeatro);
        }

        // GET: ObraDeTeatroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObraDeTeatro obraDeTeatro = db.ObraDeTeatroes.Find(id);
            string currentUserID = User.Identity.GetUserId();
            if (obraDeTeatro.UserId != currentUserID || obraDeTeatro == null)
            {
                return HttpNotFound();
            }
            return View(obraDeTeatro);
        }

        // POST: ObraDeTeatroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "obraTeatroId,Titulo,ActoresPrincipales,Ciudad,Lugar,Dias,FechaIni,FechaFin,Hora,Duracion,PrecioMin,PrecioMed,PrecioMax,DescripcionPrecios")] ObraDeTeatro obraDeTeatro)
        {
            string currentUserID = User.Identity.GetUserId();
            obraDeTeatro.UserId = currentUserID;
            
                if (ModelState.IsValid)
            {
                db.Entry(obraDeTeatro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obraDeTeatro);
        }

        // GET: ObraDeTeatroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObraDeTeatro obraDeTeatro = db.ObraDeTeatroes.Find(id);
            string currentUserID = User.Identity.GetUserId();

            if (obraDeTeatro.UserId != currentUserID || obraDeTeatro == null)
            {
                return HttpNotFound();
            }
            return View(obraDeTeatro);
        }

        // POST: ObraDeTeatroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObraDeTeatro obraDeTeatro = db.ObraDeTeatroes.Find(id);
            db.ObraDeTeatroes.Remove(obraDeTeatro);
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
