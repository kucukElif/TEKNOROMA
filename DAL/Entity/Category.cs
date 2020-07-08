using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
   public class Category:CoreEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string MainCategory { get; set; }
      
    }
}
