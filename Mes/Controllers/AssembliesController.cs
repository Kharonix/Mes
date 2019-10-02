using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mes.Models;
using Mes.Models.Platform;

namespace Mes.Controllers
{
    public class AssembliesController : Controller
    {
        private WorkOrderContext db = new WorkOrderContext();

        // GET: Assemblies
        public async Task<ActionResult> Index()
        {
            var assemblies = db.Assemblies.Include(a => a.Workplace);
            return View(await assemblies.ToListAsync());
        }

        // GET: Assemblies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assembly assembly = await db.Assemblies.FindAsync(id);
            if (assembly == null)
            {
                return HttpNotFound();
            }
            return View(assembly);
        }

        // GET: Assemblies/Create
        public ActionResult Create()
        {
            ViewBag.WorkplaceId = new SelectList(db.Workplaces, "Id", "Name");
            return View();
        }

        // POST: Assemblies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,WorkplaceId")] Assembly assembly)
        {
            if (ModelState.IsValid)
            {
                db.Assemblies.Add(assembly);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.WorkplaceId = new SelectList(db.Workplaces, "Id", "Name", assembly.WorkplaceId);
            return View(assembly);
        }

        // GET: Assemblies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assembly assembly = await db.Assemblies.FindAsync(id);
            if (assembly == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkplaceId = new SelectList(db.Workplaces, "Id", "Name", assembly.WorkplaceId);
            return View(assembly);
        }

        // POST: Assemblies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,WorkplaceId")] Assembly assembly)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assembly).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.WorkplaceId = new SelectList(db.Workplaces, "Id", "Name", assembly.WorkplaceId);
            return View(assembly);
        }

        // GET: Assemblies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assembly assembly = await db.Assemblies.FindAsync(id);
            if (assembly == null)
            {
                return HttpNotFound();
            }
            return View(assembly);
        }

        // POST: Assemblies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Assembly assembly = await db.Assemblies.FindAsync(id);
            db.Assemblies.Remove(assembly);
            await db.SaveChangesAsync();
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
