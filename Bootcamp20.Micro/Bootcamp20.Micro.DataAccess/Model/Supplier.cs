﻿using Bootcamp20.Micro.Core;
using Bootcamp20.Micro.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp20.Micro.DataAccess.Model
{
    public class Supplier : BaseModel
    {
        public string Name { get; set; }
        public Supplier()
        {

        }
        public Supplier(SupplierParam supplierParam)
        {
            this.Name = supplierParam.Name;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public virtual void Update(SupplierParam supplierParam)
        {
            this.Id = supplierParam.Id;
            this.Name = supplierParam.Name;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public virtual void Delete()
        {
            this.isDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
