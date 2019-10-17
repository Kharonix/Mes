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
    public class WorkplacesController : Controller
    {
        private WorkOrderContext db = new WorkOrderContext();

        // GET: Workplaces
        public async Task<ActionResult> Index()
        {
            return View(await db.Workplaces.ToListAsync());
        }

        // GET: Workplaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workplaces/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Workplace workplace)
        {
            if (ModelState.IsValid)
            {
                db.Workplaces.Add(workplace);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(workplace);
        }

        // GET: Workplaces/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workplace workplace = await db.Workplaces.FindAsync(id);
            if (workplace == null)
            {
                return HttpNotFound();
            }
            return View(workplace);
        }

        // POST: Workplaces/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Workplace workplace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workplace).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(workplace);
        }


        // POST: Workplaces/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Workplace workplace = await db.Workplaces.FindAsync(id);
            db.Workplaces.Remove(workplace);
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
