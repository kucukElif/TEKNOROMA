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
    public class SupplierRepository : ISupplierService
    {
        private readonly AppDbContext context;

        public SupplierRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Supplier entity)
        {
            context.Suppliers.Add(entity);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<Supplier, bool>> exp)
        {
            return context.Suppliers.Any(exp);
        }

        public List<Supplier> GetActive()
        {
            return context.Suppliers.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }

        public Supplier GetById(Guid id)
        {
            return context.Suppliers.FirstOrDefault(x => x.ID == id);
        }

        public List<Supplier> GetDeafult(Expression<Func<Supplier, bool>> exp)
        {
            return context.Suppliers.Where(exp).ToList();
        }

        public void Remove(Guid id)
        {
            Supplier supplier = GetById(id);
            supplier.Status = DAL.Entity.Enum.Status.Deleted;
            Update(supplier);
        }

        public void RemoveAll(Expression<Func<Supplier, bool>> exp)
        {
            foreach (var item in GetDeafult(exp))
            {
                item.Status = DAL.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }

        public void Update(Supplier entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
