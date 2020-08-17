using BLL.Abstract;
using DAL.Context;
using DAL.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repository
{
  public  class AppUserRepository : IAppUserService
    {
        private readonly AppDbContext context;

        public AppUserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<AppUser> GetActive()
        {
            return context.Users.ToList();
        }
    }
}
