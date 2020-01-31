using Bandanas.Contexts;
using Bandanas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Bandanas.Controllers
{
    public class TecidosController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Tecidos
        public ActionResult Index()
        {
            return View(context.Tecidos.OrderBy(t => t.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tecido tecido)
        {
            context.Tecidos.Add(tecido);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Tecido tecido = context.Tecidos.Find(id);
            if (tecido == null)
                return HttpNotFound();

            return View(tecido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tecido tecido)
        {
            if (ModelState.IsValid)
            {
                context.Entry(tecido).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tecido);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Tecido tecido = context.Tecidos.Find(id);
            if (tecido == null)
                return HttpNotFound();

            return View(tecido);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Tecido tecido = context.Tecidos.Find(id);
            if (tecido == null)
                return HttpNotFound();

            return View(tecido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Tecido tecido = context.Tecidos.Find(id);
            context.Tecidos.Remove(tecido);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}