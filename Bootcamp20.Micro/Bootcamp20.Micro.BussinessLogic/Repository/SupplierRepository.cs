using Bootcamp20.Micro.Common.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.Micro.DataAccess.Model;
using Bootcamp20.Micro.DataAccess.Param;
using Bootcamp20.Micro.DataAccess.Context;
using System.Data.Entity;

namespace Bootcamp20.Micro.BussinessLogic.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        BaseContext _context = new BaseContext();
        bool status = false;
        public bool Delete(int? id)
        {
            var getSuplier = Get(id);
            getSuplier.Delete();
            _context.Entry(getSuplier).State = EntityState.Modified;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Supplier> Get()
        {
            return _context.Suppliers.Where(x => x.isDelete == false).ToList();
        }

        public Supplier Get(int? id)
        {
            if (id == null)
            {
                Console.Write("Id is Null");
            }
            Supplier supplier = _context.Suppliers.Where(x => x.Id ==id).SingleOrDefault();
            if(supplier == null)
            {
                Console.Write("Supplier has not value");
            }
            return supplier;
        }

        public bool Insert(SupplierParam supplierParam)
        {
            var push = new Supplier(supplierParam);
            _context.Suppliers.Add(push);
            var result =_context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(SupplierParam supplierParam)
        {
            var getSuplier = Get(supplierParam.Id);
            getSuplier.Update(supplierParam);
            _context.Entry(getSuplier).State = EntityState.Modified;
            var result = _context.SaveChanges();
            if(result > 0)
            {
                status = true;
            }
            return status;
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            this.Dispose(disposing);
        }
    }
}
