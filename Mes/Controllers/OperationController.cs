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
using Mes.Service;

namespace Mes.Controllers
{
    public class OperationController : Controller
    {
        private WorkOrderRepository db = new WorkOrderRepository();
        private AssemblyRepository _assemblyService = new AssemblyRepository();
        private CustomerRepository _customerService = new CustomerRepository();
        private WorkplaceRepository _workplaceService = new WorkplaceRepository();

        // GET: Operation
        public ActionResult Index()
        {
            return View(db.GetOperation());
        }

        //// GET: Operation/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    WorkOrder workOrder = await db.WorkOrders.FindAsync(id);
        //    if (workOrder == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(workOrder);
        //}

        //// GET: Operation/Create
        //public ActionResult Create()
        //{
        //    ViewBag.AssemblyId = new SelectList(db.Assemblies, "Id", "Name");
        //    ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
        //    ViewBag.WorkplaceId = new SelectList(db.Workplaces, "Id", "Name");
        //    return View();
        //}

        //// POST: Operation/Create
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Number,StartDate,EndDate,AssemblyId,CustomerId,WorkplaceId,Count,DoneCount,WorkOrderStatus")] WorkOrder workOrder)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.WorkOrders.Add(workOrder);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.AssemblyId = new SelectList(db.Assemblies, "Id", "Name", workOrder.AssemblyId);
        //    ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", workOrder.CustomerId);
        //    ViewBag.WorkplaceId = new SelectList(db.Workplaces, "Id", "Name", workOrder.WorkplaceId);
        //    return View(workOrder);
        //}

        //// GET: Operation/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    WorkOrder workOrder = await db.WorkOrders.FindAsync(id);
        //    if (workOrder == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.AssemblyId = new SelectList(db.Assemblies, "Id", "Name", workOrder.AssemblyId);
        //    ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", workOrder.CustomerId);
        //    ViewBag.WorkplaceId = new SelectList(db.Workplaces, "Id", "Name", workOrder.WorkplaceId);
        //    return View(workOrder);
        //}

        //// POST: Operation/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Number,StartDate,EndDate,AssemblyId,CustomerId,WorkplaceId,Count,DoneCount,WorkOrderStatus")] WorkOrder workOrder)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(workOrder).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.AssemblyId = new SelectList(db.Assemblies, "Id", "Name", workOrder.AssemblyId);
        //    ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", workOrder.CustomerId);
        //    ViewBag.WorkplaceId = new SelectList(db.Workplaces, "Id", "Name", workOrder.WorkplaceId);
        //    return View(workOrder);
        //}

        //// GET: Operation/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    WorkOrder workOrder = await db.WorkOrders.FindAsync(id);
        //    if (workOrder == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(workOrder);
        //}

        //// POST: Operation/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    WorkOrder workOrder = await db.WorkOrders.FindAsync(id);
        //    db.WorkOrders.Remove(workOrder);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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
