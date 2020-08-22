using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface ICustomerService:IGenericService<Customer>
    {
       Customer GetByTc(Customer customer);
        void AddCustomerData(CustomerData customerData);
        List<CustomerData> GetCustomerDatas();
    }
}
