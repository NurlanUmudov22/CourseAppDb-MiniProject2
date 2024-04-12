using Domain.Models;
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

        //public async Task CreateUserAsync(string fullName, string username, string email, string password)
        //{
        //    //await _context.Users.(fullName, username, email, password);
        //}

        //public Task<bool> LoginAsync(string usernameOrEmail, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
