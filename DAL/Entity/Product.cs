using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entity
{
  public  class Product:CoreEntity
    {
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitsInStock { get; set; }
        public decimal UnitsonOrder { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal PurchasePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }
        public string Unit { get; set; }
        public string ImagePath { get; set; }
        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
