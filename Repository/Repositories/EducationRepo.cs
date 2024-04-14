using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Repositories
{
    public class EducationRepo :  IEducationRepository
    {
        private readonly AppDbContext _context;

        public EducationRepo()
        {
            _context = new AppDbContext();

        }

        public async Task CreateAsync(Education education)
        {
             await _context.Educations.AddAsync(education);
            await _context.SaveChangesAsync();


        }

        public async Task DeleteAsync(int? id)
        {
            _context.Remove(id);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Education>> GetAllAsync()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task<List<Education>> GetAllWithGroupsAsync()
        {
            return await _context.Educations.Include(m => m.Group).ToListAsync();
        }

        public async Task<Education> GetByIdAsync(int id)
        {
           return  await  _context.Educations.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Education>> SearchByNameAsync(string searchText)
        {
            return await  _context.Educations.Where(m => m.Name.ToLower().Trim().Contains(searchText.ToLower().Trim())).ToListAsync();

        }

        public async Task<List<Education>> SortWithCreatedDateAsync(string order)
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task UpdateAsync(Education education )
        {
            _context.Update(education.Name);
            _context.Update(education.Color);
            await _context.SaveChangesAsync();


        }



        //public async Task<Education> Update(int id)
        //{
        //    return await _context.Educations.FirstOrDefaultAsync(m => m.Id == id);
        //}


    }
}
