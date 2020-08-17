using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
  public  class Customer:CoreEntity
    {
        public string TC { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string SalesNo { get; set; }
        public bool Gender { get; set; }



    }
}
