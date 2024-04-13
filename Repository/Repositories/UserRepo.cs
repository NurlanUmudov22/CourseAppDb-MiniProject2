using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepo : IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepo()
        {
            _context = new AppDbContext();

        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        public  async Task<bool> LoginAsync(string usernameOrEmail, string password)
        {
          var data =   await _context.Users.FirstOrDefaultAsync(m=> m.UserName == usernameOrEmail || m.Email==usernameOrEmail && m.Password== password);
            if (data != null)
            {
                throw new ("Login failed");
            }
            return true;
        }
    }
}
