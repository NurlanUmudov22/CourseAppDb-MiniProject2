using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GroupRepo : IGroupRepository
    {

        private readonly AppDbContext _context;

        public GroupRepo()
        {
            _context = new AppDbContext();

        }
        public async Task DeleteAsync(int? id)
        {
            _context.Remove(id);

            await _context.SaveChangesAsync();
        }

        public Task<List<Group>> FilterByEduName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await _context.Groups.Include(m=> m.Education).ToListAsync();
        }

        
        public async  Task<List<Group>> GetAllWithEducationIdAsync(int? id)
        {
            return await _context.Groups.Include(m => m.Education).Where(m => m.EducationId == id).ToListAsync();
        }

        public async  Task<Group> GetByIdAsync(int id)
        {
            return await _context.Groups.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Group>> SearchByNameAsync(string searchText)
        {
            return await _context.Groups.Where(m => m.Name.ToLower().Trim().Contains(searchText.ToLower().Trim())).ToListAsync();

        }

        public async  Task<List<Group>> SortWithCapacityAsync(string order)
        {
            return await _context.Groups.ToListAsync();

        }

        public Task<Group> Update(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
