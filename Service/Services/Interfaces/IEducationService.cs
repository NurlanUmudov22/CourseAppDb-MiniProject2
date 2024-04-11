using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IEducationService
    {


        Task<List<Education>> GetAllAsync(); //+

        Task<Education> GetByIdAsync(int id);  //+

        Task DeleteAsync(int? id);  //+

        Task<List<Education>> SearchByNameAsync(string searchText);  //+

        Task<List<Education>> GetAllWithGroupsAsync();

        Task<List<Education>> SortWithCreatedDateAsync(string order);


        Task<Education> Update(Education education);





    }
}
