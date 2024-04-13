using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Task<List<Domain.Models.Group>> GetAllAsync();

        Task<Domain.Models.Group> GetByIdAsync(int id);

        Task DeleteAsync(int? id);

        Task<List<Domain.Models.Group>> SearchByNameAsync(string searchText);
        Task<List<Domain.Models.Group>> GetAllWithEducationIdAsync(int? id);

        Task<List<Domain.Models.Group>> SortWithCapacityAsync(string order);


        Task<Group> Update(Group group);

        Task<List<Domain.Models.Group>> FilterByEduNameAsync(string name);
    }
}
