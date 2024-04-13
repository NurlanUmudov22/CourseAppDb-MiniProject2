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

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();

        }
    }
}
