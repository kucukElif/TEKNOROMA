using DAL.Entity;
using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity.Enum
{
   public class Category:CoreEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Guid? MainCategory { get; set; }
    }
}
