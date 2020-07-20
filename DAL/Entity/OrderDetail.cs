using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entity
{
   public class OrderDetail:CoreEntity
    {
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? UnitPrice { get; set; }
        public short? Quantity { get; set; }
        public Guid OrderID { get; set; }
        public string BarcodeNo { get; set; }

        public decimal GetTotalPrice()
        {
            return Convert.ToDecimal(UnitPrice * Quantity);
        }
    }
}
