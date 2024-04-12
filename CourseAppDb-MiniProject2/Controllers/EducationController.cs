using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAppDb_MiniProject2.Controllers
{
    public  class EducationController
    {
        private readonly EducationService _educationService;

        public EducationController()
        {
            _educationService = new EducationService();
        }

        public async Task DeleteAsync()
        {
            ConsoleColor.Blue.WriteConsole("Add Education id:");
            Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)            
                try
            {              
                await _educationService.DeleteAsync(id);
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
            var datas = await _educationService.GetAllAsync();
            if(datas.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Data NotFound");
            }

            foreach (var item in datas)
            {
                string data = $"Name: {item.Name}, Color : {item.Color}";
                ConsoleColor.Cyan.WriteConsole(data);

            }
        }

        public async Task GetByIdAsync()
        {
            ConsoleColor.Blue.WriteConsole("Add Education id:");
            Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)


            try
            {
                var data = await _educationService.GetByIdAsync(id);


                string result = $"Name: {data.Name}, Color: {data.Color}";
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
            ConsoleColor.Blue.WriteConsole("Add EDUCATION name:");
            Name: string searchText = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }


            try
            {
                var result = await _educationService.SearchByNameAsync(searchText);

                if (result.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Data notfound");
                    goto Name;

                }


                foreach (var item in result)
                {
                    string data = $" Education name: {item.Name}, Color : {item.Color}";
                    ConsoleColor.Cyan.WriteConsole(data);
                }


            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Name;
            }
        }

        public async Task GetAllWithGroupsAsync()
        {

            try
            {
                var educations = await _educationService.GetAllWithGroupsAsync();

                if (educations.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole("Data notfound");
                }
                foreach (var item in educations)
                {
                    string result = $"Name: {item.Name}, Groups: {string.Join(", ", item.Education.Name)}";
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public async Task SortWithCreatedDate()
        {
            ConsoleColor.Blue.WriteConsole("Choose filter: ");
        Name: string order = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(order))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }

            try
            {
                var educations = await _educationService.GetAllAsync();
               

                foreach (var item in educations)
                {
                    string data = $" Education name: {item.Name}, Color : {item.Color}, CreatedDate: {item.CreatedDate}";
                    ConsoleColor.Cyan.WriteConsole(data);
                }

            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }

        }


    }
}
