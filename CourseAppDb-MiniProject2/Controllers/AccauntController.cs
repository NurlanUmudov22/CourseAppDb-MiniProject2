using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseAppDb_MiniProject2.Controllers
{
    public class AccauntController
    {
        private readonly AccountService _accauntService;
        private readonly UserServise _userServise;

        public bool  LoginSuccess { get; set; }

        public AccauntController()
        {
            _accauntService = new AccountService();
            _userServise = new UserServise();
        }




        public async Task RegisterAsync()
        {
            ConsoleColor.Magenta.WriteConsole("Welcome to our course");

            ConsoleColor.Blue.WriteConsole(" Please add your FullName:");
        Name: string fullName = Console.ReadLine();
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
        Username: string userName = Console.ReadLine();
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
            var userN = await _userServise.GetAllAsync();
            if (userN.Any(m => m.UserName == userName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Email;
            }

            ConsoleColor.Blue.WriteConsole("Please add your email:");
        Email: string email = Console.ReadLine();
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

            var user = await _userServise.GetAllAsync();
            if (user.Any(m => m.Email == email))
            {
                ConsoleColor.Red.WriteConsole("Please add new email. This email has");
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
            ConsoleColor.Blue.WriteConsole("Confirm password:");
            CPassword: string confirmPassword = Console.ReadLine();
            if(confirmPassword != password)
            {
                ConsoleColor.Red.WriteConsole("confirm password is wrong, please add again");
                goto CPassword;
            }
            else
            {
                try
                {

                    await _accauntService.RegisterAsync(new Domain.Models.User { FullName = fullName, UserName = userName, Email = email, Password = password, CreatedDate=DateTime.Now});
                    ConsoleColor.Green.WriteConsole("User successfully added");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Name;
                }
            }


        }

        public async Task LoginAsync()
        {
            ConsoleColor.Yellow.WriteConsole("Login:");

            ConsoleColor.Blue.WriteConsole("Please add your email or Username:");
        Email: string emailOrUserName = Console.ReadLine();
           
            if (string.IsNullOrWhiteSpace(emailOrUserName))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Email;
            }

            ConsoleColor.Blue.WriteConsole("Please add your password:");
            Password: string password = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Password;
            }

            var login = await _accauntService.LoginAsync(emailOrUserName,password);
            if (login)
            {
                LoginSuccess=true;
                ConsoleColor.Green.WriteConsole("Login success");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Login failed, please try again");
                goto Email;
            }



        }


    }
}
