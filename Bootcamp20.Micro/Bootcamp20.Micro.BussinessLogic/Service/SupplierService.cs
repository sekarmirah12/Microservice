using Bootcamp20.Micro.BussinessLogic.Service;
using Bootcamp20.Micro.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.Micro.DataAccess.Model;
using Bootcamp20.Micro.DataAccess.Param;
using Bootcamp20.Micro.Common.Interfaces.Application;

namespace Bootcamp20.Micro.BussinessLogic.Service
{
    public class SupplierService : ISupplierService
    {
        // buat manggil function yang sudah dibuat di supplier repository
        private readonly ISupplierRepository _supplierRepository;
        bool status = false;
        public SupplierService (){  }
        
        //menghubungkan interface ke class
        public SupplierService (ISupplierRepository supplierRepository)
        {
            this._supplierRepository = supplierRepository;
        }

        public bool Delete(int? id)
        {
            return _supplierRepository.Delete(id);
        }

        public List<Supplier> Get()
        {
            return _supplierRepository.Get();
        }

        public Supplier Get(int? id)
        {
            return _supplierRepository.Get(id);
        }

        public bool Insert(SupplierParam supplierParam)
        {
            return _supplierRepository.Insert(supplierParam);
        }

        public bool Update(SupplierParam supplierParam)
        {
            return _supplierRepository.Update(supplierParam);
        }
    }
}
