using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp20.Micro.DataAccess.Model;

namespace Bootcamp20.Micro.DataAccess.Param
{
   public class SupplierParam
    {
        public SupplierParam ()
        {

        }
        public SupplierParam(Supplier supplier)
        {
            Id = supplier.Id;
            Name = supplier.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
