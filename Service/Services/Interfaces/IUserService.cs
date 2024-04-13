using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);

        Task<bool> LoginAsync(string userNameOrEmail, string password);
    }
}
