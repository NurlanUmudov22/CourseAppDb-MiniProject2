using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseAppDb_MiniProject2.Controllers
{
    public  class UserController
    {

        private readonly UserServise _userService ;

        public UserController()
        {
            _userService = new UserServise();
        }

        public async Task GetAllAsync()
        {
            var datas = await _userService.GetAllAsync();
            if (datas.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Data NotFound");
            }

            foreach (var item in datas)
            {
                string data = $"FullName: {item.FullName}, UserName: {item.UserName}, Email: {item.Email},";
                ConsoleColor.Cyan.WriteConsole(data);

            }
        }



    }
}
