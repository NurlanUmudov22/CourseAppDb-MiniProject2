using Domain.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseAppDb_MiniProject2.Controllers
{
    public class GroupController
    {
        private readonly GroupService _groupService;
        //private readonly EducationService _educationService;

        public GroupController()
        {
            _groupService = new GroupService();
            //_educationService = new EducationService();
        }

        public async Task DeleteAsync()
        {
            ConsoleColor.Blue.WriteConsole("Add group id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
                try
                {
                    await _groupService.DeleteAsync(id);
                    ConsoleColor.Green.WriteConsole("Data successfully deleted");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;
            }
        }

        public async Task GetAllAsync()
        {
            var datas = await _groupService.GetAllAsync();
            if (datas.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Data NotFound");

            }

            foreach (var item in datas)
            {
                string data = $"Id: {item.Id},Name: {item.Name}, Capacity: {item.Capacity}, Education: {item.Education.Name}, CreatedDate: {item.CreatedDate}";
                ConsoleColor.Cyan.WriteConsole(data);

            }
        }

        public async Task GetByIdAsync()
        {
            ConsoleColor.Blue.WriteConsole("Add group id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)


                try
                {
                    var data = await _groupService.GetByIdAsync(id);


                    string result = $"Name: {data.Name}, Capacity: {data.Capacity}, Education: {data.Education.Name} ";
                    ConsoleColor.Cyan.WriteConsole(result);
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;

                }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;
            }
        }

        public async Task SearchByNameAsync()
        {
            ConsoleColor.Blue.WriteConsole("Add group name:");
        Name: string searchText = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }


            try
            {
                var result = await _groupService.SearchByNameAsync(searchText);

                if (result.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Data notfound");
                    goto Name;

                }


                foreach (var item in result)
                {
                    string data = $"Name: {item.Name}, Capacity: {item.Capacity}, Education: {item.Education.Name} ";
                    ConsoleColor.Cyan.WriteConsole(data);
                }


            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Name;
            }
        }


        public async Task GetAllWithEducationIdAsync()
        {
            ConsoleColor.Blue.WriteConsole("Add Education id:");
        Id: string eduId = Console.ReadLine();

            int id;
            bool isCorrectIdFormat = int.TryParse(eduId, out id);
            if (isCorrectIdFormat)

                try
                {

                    var datas = await _groupService.GetAllWithEducationIdAsync(id);

                    if (datas.Count == 0)
                    {
                        ConsoleColor.Red.WriteConsole("Data NotFound");
                        goto Id;
                    }

                    foreach (var item in datas)
                    {
                        string data = $"Name: {item.Name}, Education: {item.Education.Name}";
                        ConsoleColor.Cyan.WriteConsole(data);

                    }
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;

                }

            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;
            }

        }


        public async Task FilterByEduNameAsync()
        {
            ConsoleColor.Blue.WriteConsole("Add education name:");
        Edu: string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Edu;
            }
            else
            {
                try
                {

                    var result = await _groupService.FilterByEduNameAsync(name);
                    if (result.Count != 0)
                    {
                        foreach (var item in result)
                        {
                            string data = $"Group Name: {item.Name}, Education: {item.Education.Name}";
                            ConsoleColor.Cyan.WriteConsole(data);
                        }
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("There is no education with this name");
                        goto Edu;
                    }


                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Edu;

                }
            }
        }


        public async Task SortWithCapacityAsync()
        {
            ConsoleColor.Blue.WriteConsole("Write filter: Asc: A /  Desc: Z ");
        Name: string order = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(order))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }

            try
            {

                var groups = await _groupService.SortWithCapacityAsync(order);

                if (order == "A")
                {
                    foreach (var item in groups)
                    {
                        string data = $" Group name: {item.Name}, Capacity : {item.Capacity}";
                        ConsoleColor.Cyan.WriteConsole(data);
                    }
                }
                else if (order == "Z")
                {
                    foreach (var item in groups)
                    {
                        string data = $" Group name: {item.Name}, Capacity : {item.Capacity}";
                        ConsoleColor.Cyan.WriteConsole(data);
                    }
                }



            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Name;
            }
        }

        public async Task CreateGroupAsync()
        {
            ConsoleColor.Blue.WriteConsole("Add Group name:");
          Name: string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;


            }
            if (name.Count() > 30)
            {
                ConsoleColor.Red.WriteConsole("The group name cannot be more than 30 characters");
                goto Name;
            }
            var data = await _groupService.GetAllAsync();
            if (data.Any(m => m.Name.ToLower() == name.ToLower()))
            {
                ConsoleColor.Red.WriteConsole("Group names can not be the same");
                goto Name;
            }
           


            ConsoleColor.Blue.WriteConsole("Add capacity;");
             Capa:  string capacity = Console.ReadLine();

            int Cap;
            bool isCorrectidCapFormat = int.TryParse(capacity, out Cap);
            if (isCorrectidCapFormat)
            {
                ConsoleColor.Blue.WriteConsole("Add education Id:");
            Id: string idStr = Console.ReadLine();
                int id;
                bool isCorrectIdFormat = int.TryParse(idStr, out id);
                //if (isCorrectIdFormat= false ) 
                //{
                //    ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                //    goto Capa;

                //}
                if (isCorrectIdFormat)
                {
                    try
                    {
                        //var datass = await  _educationService.GetAllAsync();

                        await _groupService.CreateGroupAsync(new Domain.Models.Group { Name = name,  Capacity = Cap, EducationId = id , CreatedDate = DateTime.Now });
                        ConsoleColor.Green.WriteConsole("Education successfully added");


                    }
                    catch (Exception ex)
                    {
                        ConsoleColor.Red.WriteConsole(ex.Message);
                        goto Id;

                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                    goto Id;
                }
            }
            
        }















         

        

    }
}
