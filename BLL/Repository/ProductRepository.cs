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
   public class ProductRepository : IProductService
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Product entity)
        {
            context.Products.Add(entity);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<Product, bool>> exp)
        {
            return context.Products.Any(exp);
        }

        public List<Product> GetActive()
        {
            return context.Products.Where(x => x.Status == DAL.Entity.Enum.Status.Active).ToList();
        }

        public Product GetById(Guid id)
        {
           return context.Products.FirstOrDefault(x => x.ID == id);
        }

        public List<Product> GetDeafult(Expression<Func<Product, bool>> exp)
        {
            return context.Products.Where(exp).ToList();
        }

        public List<Product> GetTop10Products()
        {
            return context.Products.OrderByDescending(i => i.ID).Take(10).ToList();
        }

        public List<Product> ListProductByCategory(Guid id)
        {
            return context.Products.Where(x => x.CategoryID == id).ToList();
        }

        public void Remove(Guid id)
        {
            Product product = GetById(id);
            product.Status = DAL.Entity.Enum.Status.Deleted;
            Update(product);
        }

        public void RemoveAll(Expression<Func<Product, bool>> exp)
        {
            foreach (var item in GetDeafult(exp))
            {
                item.Status = DAL.Entity.Enum.Status.Deleted;
                Update(item);
            }        
        }

        public void Update(Product entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
