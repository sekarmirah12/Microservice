using Bootcamp20.Micro.Common.Interfaces;
using Bootcamp20.Micro.DataAccess.Model;
using Bootcamp20.Micro.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Bootcamp20.Micro.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        private readonly ISupplierService _supplierService;
        
        public SuppliersController() { }
        public SuppliersController(ISupplierService supplierService)
        {
            this._supplierService = supplierService;
        }
        
        public ActionResult Index()
        {
            IEnumerable<SupplierParam> list_param = _supplierService.Get().Select(x => new SupplierParam
            {
                Id = x.Id,
                Name = x.Name
            });
            return View(list_param);
        }

        //GET : Item Create
        public ActionResult Insert()
        {
            return View();

        }

        [HttpPost]
        
        //POST : Item 
        public ActionResult Insert(SupplierParam supplierParam)
        {
            _supplierService.Insert(supplierParam);
            return RedirectToAction("Index");
        }
        //GET 
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var supplier = _supplierService.Get(id);
            var supparam = new SupplierParam(supplier);
            return View(supparam);
        }
        //POST
        [HttpPost]
        public ActionResult Update(SupplierParam supplierParam)
        {
            _supplierService.Update(supplierParam);
            return RedirectToAction("Index");
        }
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var supplier = _supplierService.Get(id);
        //    var supparam = new SupplierParam(supplier);
        //    if (supplier == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(supparam);
        //}

        // POST: Suppliers/Delete/5
        [HttpPost]
       
        public ActionResult Delete(int id)
        {
            _supplierService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}