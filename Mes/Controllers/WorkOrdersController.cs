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
using Mes.Service.Abstract;
using Mes.Service;

namespace Mes.Controllers
{
    public class WorkOrdersController : Controller
    {
        //private WorkOrderContext db = new WorkOrderContext();
        private readonly IBaseDocument<WorkOrder> _workOrderService;
        private readonly IBaseDocument<Assembly> _assemblyService;
        private readonly IBaseDocument<Customer> _customerService;
        private readonly IBaseDocument<Workplace> _workplaceService;
        public WorkOrdersController() {
            _workOrderService = new WorkOrderRepository();
            _assemblyService = new AssemblyRepository();
            _customerService = new CustomerRepository();
            _workplaceService = new WorkplaceRepository();
        }
        // GET: WorkOrders
        public ActionResult Index()
        {
            return View(_workOrderService.GetAll());
        }

        // GET: WorkOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = _workOrderService.Get(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // GET: WorkOrders/Create
        public ActionResult Create()
        {
            ViewBag.AssemblyId = new SelectList(_assemblyService.GetAll(), "Id", "Name");
            ViewBag.CustomerId = new SelectList(_customerService.GetAll(), "Id", "Name");
            ViewBag.WorkplaceId = new SelectList(_workplaceService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: WorkOrders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,StartDate,EndDate,AssemblyId,CustomerId,WorkplaceId,Count,DoneCount,WorkOrderStatus")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                _workOrderService.Create(workOrder);
                _workOrderService.Save();
                return RedirectToAction("Index");
            }

            ViewBag.AssemblyId = new SelectList(_assemblyService.GetAll(), "Id", "Name", workOrder.AssemblyId);
            ViewBag.CustomerId = new SelectList(_customerService.GetAll(), "Id", "Name", workOrder.CustomerId);
            ViewBag.WorkplaceId = new SelectList(_workplaceService.GetAll(), "Id", "Name", workOrder.WorkplaceId);
            return View(workOrder);
        }

        // GET: WorkOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = GetViewBag((int)id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // POST: WorkOrders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,StartDate,EndDate,AssemblyId,CustomerId,WorkplaceId,Count,DoneCount,WorkOrderStatus")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                _workOrderService.Update(workOrder);
                _workOrderService.Save();
                return RedirectToAction("Index");
            }
            ViewBag.AssemblyId = new SelectList(_assemblyService.GetAll(), "Id", "Name", workOrder.AssemblyId);
            ViewBag.CustomerId = new SelectList(_customerService.GetAll(), "Id", "Name", workOrder.CustomerId);
            ViewBag.WorkplaceId = new SelectList(_workplaceService.GetAll(), "Id", "Name", workOrder.WorkplaceId);
            return View(workOrder);
        }

        // GET: WorkOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = _workOrderService.Get(id);
            ViewBag.AssemblyId = new SelectList(_assemblyService.GetAll(), "Id", "Name", workOrder.AssemblyId);
            ViewBag.CustomerId = new SelectList(_customerService.GetAll(), "Id", "Name", workOrder.CustomerId);
            ViewBag.WorkplaceId = new SelectList(_workplaceService.GetAll(), "Id", "Name", workOrder.WorkplaceId);
            if (workOrder == null)
            {
                return HttpNotFound();
            }

            return View(workOrder);

        }

        // POST: WorkOrders/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _workOrderService.Delete(id);
            _workOrderService.Save();

            return RedirectToAction("Index");
        }
        public WorkOrder GetViewBag(int id) {
            WorkOrder workOrder = _workOrderService.Get(id);
            ViewBag.AssemblyId = new SelectList(_assemblyService.GetAll(), "Id", "Name", workOrder.AssemblyId);
            ViewBag.CustomerId = new SelectList(_customerService.GetAll(), "Id", "Name", workOrder.CustomerId);
            ViewBag.WorkplaceId = new SelectList(_workplaceService.GetAll(), "Id", "Name", workOrder.WorkplaceId);
            return workOrder;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _workOrderService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
