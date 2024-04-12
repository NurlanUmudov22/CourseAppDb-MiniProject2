using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    internal class UserServise : IUserService
    {

        private readonly AppDbContext _context;

        public UserServise()
        {
            _context = new AppDbContext();

        }

        //public Task CreateUserAsync(string fullName, string username, string email, string password)
        //{
        //    await _context.CreateUserAsync(fullName, username, email, password);
        //}

        //public Task<bool> LoginAsync(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
