using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace BLL.Abstract
{
   public interface IGenericService<T> where T : class
    {
        List<T> GetActive();
        List<T> GetDeafult(Expression<Func<T, bool>> exp);
        void Add(T entity);
        void Update(T entity);
        void Remove(Guid id);
        void RemoveAll(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T GetById(Guid id);

    }
}
