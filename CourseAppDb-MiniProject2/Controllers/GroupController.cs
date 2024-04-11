using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAppDb_MiniProject2.Controllers
{
    public class GroupController
    {
        private readonly GroupService _groupService;

        public GroupController()
        {
            _groupService = new GroupService();
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
                string data = $"Name: {item.Name}, Capacity: {item.Capacity}, Education: {item.Education.Name} ";
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
    }
}
