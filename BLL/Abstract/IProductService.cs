using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
  public  interface IProductService :IGenericService<Product>
    {
        List<Product> GetTop10Products();
        List<Product> ListProductByCategory(Guid id);
    }
}
