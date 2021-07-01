using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PustokHomework.DAL;
using PustokHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Areas.Manage.Services
{
    public class DashboardLayoutViewModelService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public DashboardLayoutViewModelService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        [Authorize(Roles ="Admin")]
        public List<AppUser> GetFullName()
        {
            return _context.Users.Where(x => x.IsAdmin).ToList();
        }
    }
}
