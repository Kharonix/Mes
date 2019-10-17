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
            return View(await db.Assemblies.ToListAsync());
        }

   
        // GET: Assemblies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assemblies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Assembly assembly)
        {
            if (ModelState.IsValid)
            {
                db.Assemblies.Add(assembly);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

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
            return View(assembly);
        }

        // POST: Assemblies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Assembly assembly)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assembly).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(assembly);
        }

        // POST: Assemblies/Delete/5
        [HttpDelete]
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
