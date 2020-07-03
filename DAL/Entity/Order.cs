using DAL.Entity;
using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
  public  class Order:CoreEntity
    {
        public Order()
        {
            this.Confirmed = false;
            ProductOrders = new List<ProductOrder>();

        }
        public Guid AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public Guid CustomerId { get; set; }
        public bool Confirmed { get; set; }
        public DateTime? OrderDate { get; set; }
        public virtual List<ProductOrder> ProductOrders { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
