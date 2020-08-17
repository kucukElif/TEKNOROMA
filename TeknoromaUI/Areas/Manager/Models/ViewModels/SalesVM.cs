using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeknoromaUI.Areas.Manager.Models.ViewModels
{
    public class SalesVM
    {
        public List<Product> Product { get; set; }
        public List<AppUser> AppUser { get; set; }
        public List<Category> Category { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
