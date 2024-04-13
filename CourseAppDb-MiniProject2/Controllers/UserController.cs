using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
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


        //----
        public async Task CreateUserAsync()
        {
            ConsoleColor.Magenta.WriteConsole("Welcome to our course");

            ConsoleColor.Blue.WriteConsole(" Please add your FullName:");
             Name:  string fullName = Console.ReadLine();
            if (!Regex.IsMatch(fullName, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Name;
            }
            if (string.IsNullOrWhiteSpace(fullName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }

            ConsoleColor.Blue.WriteConsole("Please add your UserName:");
            Username:  string userName = Console.ReadLine();
            if (!Regex.IsMatch(userName, "^[A-Za-z][A-Za-z0-9_]{7,29}$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Username;
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Username;
            }

            ConsoleColor.Blue.WriteConsole("Please add your email:");
            Email:  string email = Console.ReadLine();
            if (!Regex.IsMatch(email, @"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Email;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Email;
            }
            

            ConsoleColor.Blue.WriteConsole("Please add your password:");
            Password: string password = Console.ReadLine();
            if (!Regex.IsMatch(password, @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Password;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Password;
            }
            else
            {
                try
                {
                    if (email.Length > 1)
                    {
                        throw new("This email has. Please add new email");
                    }
                    if (userName.Length > 1)
                    {
                        throw new("This username has. Please add new username");
                    }

                    await _userService.CreateUserAsync(new Domain.Models.User { FullName = fullName, UserName= userName, Email= email, Password= password });
                    ConsoleColor.Green.WriteConsole("User successfully added");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Name;
                }
            }
            //else
            //{

            //    ConsoleColor.Red.WriteConsole();
            //    goto Name;

            //}


}
    }
}
