using BLL.Abstract;
using DAL.Context;
using DAL.Entity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Repository
{
    public class CustomerRepository : ICustomerService
    {
        private readonly AppDbContext context;

        public CustomerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Customer entity)
        {
            context.Customers.Add(entity);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<Customer, bool>> exp)
        {
            return context.Customers.Any(exp);
        }

        public List<Customer> GetActive()
        {
            return context.Customers.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }

        public Customer GetById(Guid id)
        {
            return context.Customers.FirstOrDefault(x => x.ID == id);
        }

        public List<Customer> GetDeafult(Expression<Func<Customer, bool>> exp)
        {
            return context.Customers.Where(exp).ToList();
        }

        public void Remove(Guid id)
        {
            Customer customer = GetById(id);
            customer.Status = DAL.Entity.Enum.Status.Deleted;
            Update(customer);
        }

        public void RemoveAll(Expression<Func<Customer, bool>> exp)
        {
            foreach (var item in GetDeafult(exp))
            {
                item.Status = DAL.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }

        public void Update(Customer entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
