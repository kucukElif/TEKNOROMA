using DAL.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
 public   class Expense:CoreEntity
    {
        public string OperationType { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Costumer Costumer { get; set; }
    }
}
