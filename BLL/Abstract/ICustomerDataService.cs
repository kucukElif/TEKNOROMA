using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
   public interface ICustomerDataService
    {
        List<CustomerData> GetActive();

    }
}
