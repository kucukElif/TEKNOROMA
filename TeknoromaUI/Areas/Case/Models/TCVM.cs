using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entity;

namespace TeknoromaUI.Areas.Case.Models
{
    public class TCVM
    {
        public string TC { get; set; }
        public Customer Customer { get; set; }
        public List<CustomerData> CustomerDatas { get; set; }
    }
}
