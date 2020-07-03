using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
  public  class Costumer :CoreEntity
    {
        public string TC { get; set; }
        public string CostumerName { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string CompanyName { get; set; }


    }
}
