using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
   public class AppUser : IdentityUser<Guid>
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public bool Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal Salary { get; set; }


        //public virtual List<Product> Products { get; set; }
        //public virtual List<Order> Orders { get; set; }


    }
}
