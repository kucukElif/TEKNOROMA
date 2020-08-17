using DAL.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IAppUserService
    {
        List<AppUser> GetActive();
        
    }
}
