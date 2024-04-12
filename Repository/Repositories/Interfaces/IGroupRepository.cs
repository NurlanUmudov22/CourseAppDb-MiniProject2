using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IGroupRepository
    {

        Task<List<Group>> GetAllAsync(); //+

        Task<Group> GetByIdAsync(int id); //+

        Task DeleteAsync(int? id);  //+
         
        Task<List<Group>> SearchByNameAsync(string searchText); //+
        Task<List<Group>> GetAllWithEducationIdAsync(int? id);  //+

        Task<List<Group>> SortWithCapacityAsync(string order); //+


        Task<Group> Update(Group group);

        Task<List<Group>> FilterByEduNameAsync(string name); //+

        //Task<List<Group>> GetAllWithEduIdAsync(int id);

    }
}
