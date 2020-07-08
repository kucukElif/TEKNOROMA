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
    public class OrderRepository : IOrderService
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Order entity)
        {
            context.Orders.Add(entity);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<Order, bool>> exp)
        {
            return context.Orders.Any(exp);
        }

        public List<Order> GetActive()
        {
            return context.Orders.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();

        }

        public Order GetById(Guid id)
        {
            return context.Orders.FirstOrDefault(x => x.ID == id);
        }

        public List<Order> GetDeafult(Expression<Func<Order, bool>> exp)
        {
            return context.Orders.Where(exp).ToList();
        }

        public void Remove(Guid id)
        {
            Order order = GetById(id);
            order.Status = DAL.Entity.Enum.Status.Deleted;
            Update(order);
        }

        public void RemoveAll(Expression<Func<Order, bool>> exp)
        {
            foreach (var item in GetDeafult(exp))
            {
                item.Status = DAL.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }

        public void Update(Order entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
