using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserServise : IUserService
    {

        private readonly AppDbContext _context;

        public UserServise()
        {
            _context = new AppDbContext();

        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            //if (user.Email.Length > 1)
            //{
            //    throw new ("This email has. Please add new email");          
            //}
            //if (user.UserName.Length >1)
            //{
            //    throw new("This username has. Please add new username");
            //}

        }

        public async Task<bool> LoginAsync(string usernameOrEmail, string password)
        {
            var data = await _context.Users.FirstOrDefaultAsync(m => m.UserName == usernameOrEmail || m.Email == usernameOrEmail && m.Password == password);
            if (data != null)
            {
                throw new("Login failed");
            }
            return true;
        }
    }
}
