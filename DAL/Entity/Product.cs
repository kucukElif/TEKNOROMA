using DAL.Entity;
using DAL.Entity.Base;
using DAL.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
  public  class Product : CoreEntity
    {
        public string BarcodeNo { get; set; }
        public string ProductName { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImagePath { get; set; }
        public Guid CategoryId { get; set; }
        public virtual ProductOrder ProductOrder { get; set; }
        public virtual Category Category { get; set; }
        public Guid CategoryID { get; set; }
        public virtual AppUser AppUser { get; set; }




    }
}
