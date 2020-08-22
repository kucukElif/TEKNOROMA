using BLL.Abstract;
using DAL.Context;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repository
{
    public class CustomerDataRepository : ICustomerDataService
    {
        private readonly AppDbContext context;

        public CustomerDataRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<CustomerData> GetActive()
        {
            return context.CustomerDatas.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }
    }
}
