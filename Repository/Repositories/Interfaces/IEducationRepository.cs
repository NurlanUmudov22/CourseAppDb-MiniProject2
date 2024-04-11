using Domain.Models;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IEducationRepository
    {
        
        Task<List<Education>> GetAllAsync(); //+

        Task<Education> GetByIdAsync(int id); //+

        Task DeleteAsync(int? id);  //+

        Task<List<Education>> SearchByNameAsync(string searchText); //+

        Task<List<Education>> GetAllWithGroupsAsync();

        Task<List<Education>> SortWithCreatedDateAsync(string order);


        Task<Education> Update(int id);
    }
}
