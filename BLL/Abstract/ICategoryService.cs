using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
 public   interface ICategoryService:IGenericService<Category>
    {
        Category GetByName(string name);
    }
}
