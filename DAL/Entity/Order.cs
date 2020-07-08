using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Entity
{
  public  class Order:CoreEntity
    {
        public Order()
        {
            this.Confirmed = false;
            OrderDetails = new List<OrderDetail>();
        }
        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
        public bool Confirmed { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal Total { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
