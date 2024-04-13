using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupService
    {

        private readonly AppDbContext _context;

        public GroupService()
        {
            _context = new AppDbContext();

        }

        public async Task CreateGroupAsync(Domain.Models.Group group)
        {
            var data = await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();

            if (data == null) throw new ArgumentNullException();


        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            var data = _context.Groups.FirstOrDefault(m => m.Id == id);

            if (data == null)
            {
                throw new("Data not found");
            }

            _context.Groups.Remove(data);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Domain.Models.Group>> FilterByEduNameAsync(string name)
        {
            var data = await _context.Groups.Include(m => m.Education).Where(m => m.Education.Name == name).ToListAsync();
            if (data == null)
            {
                throw new NotFoundException ("Data not found");
            }

            return data;
        }

        public async Task<List<Domain.Models.Group>> GetAllAsync()
        {
            return await _context.Groups.Include(m=>m.Education).ToListAsync();
        }

        public async Task<List<Domain.Models.Group>> GetAllWithEducationIdAsync(int? id)
        {
            //if (id == null) throw new ArgumentNullException(nameof(id));

            var data = await _context.Groups.Include(m => m.Education).Where(m => m.EducationId == id).ToListAsync();
            if (data == null)
            {
                throw new NotFoundException ("Data not found");
            }

            return data;

        }

        public async Task<Domain.Models.Group> GetByIdAsync(int id)
        {
            var data = await  _context.Groups.FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                throw new NotFoundException("Data not found");
            }
            return data;
        }

        public async Task<List<Domain.Models.Group>> SearchByNameAsync(string searchText)
        {
            var search = await _context.Groups.Where(m => m.Name.ToLower().Trim().Contains(searchText.ToLower().Trim())).ToListAsync();

            if (search == null)
            {
                throw new NotFoundException("Data not found");
            }
            return search;
        }

        public  async Task<List<Domain.Models.Group>> SortWithCapacityAsync(string order)
        {
            if (order == "A")
            {
                return await _context.Groups.OrderBy(m => m.Capacity).ToListAsync();

            }
            else if (order == "Z")
            {
                return await _context.Groups.OrderByDescending(m => m.Capacity).ToListAsync();

            }
            else
            {
                throw new ("Invalid filter");
            }
        }

        public Task<Group> Update(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
