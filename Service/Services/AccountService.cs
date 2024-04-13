using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;

        public AccountService()
        {
            _context = new AppDbContext();

        }
        public async Task<bool> LoginAsync(string userNameOrEmail, string password)
        {
            var data = await _context.Users.FirstOrDefaultAsync(m => (m.UserName.ToLower().Trim() == userNameOrEmail.ToLower().Trim() || m.Email.ToLower().Trim() == userNameOrEmail.ToLower().Trim()) && m.Password == password); ;
            if (data == null)
            {
                return false;   
            }
            return true;
        }

        public async Task RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
        }
    }
}
