using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using PustokHomework.DAL;
using PustokHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework
{
    public class PustokHub:Hub
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public PustokHub(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public override Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated )
            {
                AppUser user = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;
                user.ConnectionId = Context.ConnectionId;
                user.IsOnline = true;

                var result = _userManager.UpdateAsync(user).Result;
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            AppUser user = _context.Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

            if (user != null)
            {
                user.IsOnline = false;
                user.DIsconnectedAt = DateTime.UtcNow.AddHours(4);
                var result = _userManager.UpdateAsync(user).Result;
            }
            return base.OnDisconnectedAsync(exception);
        }
    }

}
