using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Service.Helpers.Enums;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EducationService : IEducationService

    {

        private readonly AppDbContext _context;

        public EducationService()
        {
            _context = new AppDbContext();

        }


        public async Task DeleteAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            var data = _context.Educations.FirstOrDefault(m => m.Id == id);

            if (data == null)
            {
                throw new ("Data not found");
            }

            _context.Educations.Remove(data);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Education>> GetAllAsync()
        {
            
          return await _context.Educations.ToListAsync();
            
        }

        public async Task<List<Domain.Models.Group>> GetAllWithGroupsAsync()
        {
            var educations = await _context.Groups.Include(m => m.Education.Group).ToListAsync();
            if (educations.Count == 0)
            {
                throw new NotFoundException("Data not found");
            }
            return educations;
        }

        public  async Task<Education> GetByIdAsync(int id)
        {
            var data = await _context.Educations.FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                throw new NotFoundException("Data not found");
            }
            return data;
        }

        public async Task<List<Education>> SearchByNameAsync(string searchText)
        {
            var search = await _context.Educations.Where(m => m.Name.ToLower().Trim().Contains(searchText.ToLower().Trim())).ToListAsync();

            if (search == null)
            {
                throw new NotFoundException("Data not found");
            }
            return search;
        }

        public async Task<List<Education>> SortWithCreatedDateAsync(string order)
        {
            switch (order)
            {
                case nameof(SortWithCreatedDate.asc):
                    return await _context.Educations.OrderBy(m => m.CreatedDate).ToListAsync();
                case nameof(SortWithCreatedDate.desc):
                    return await _context.Educations.OrderByDescending(m => m.CreatedDate).ToListAsync();
            }
            return  await _context.Educations.ToListAsync();
        }

        public Task<Education> UpdateAsync(int id, string name)
        {
            throw new NotImplementedException();
        }


        //--
        //public async Task<Education> UpdateNameAsync(int id, string name)
        //{
        //    var education = await _context.Educations.Update(id);

        //    if (education == null)
        //    {
        //        throw new NotFoundException("Data not found");

        //    }
        //    else
        //    {
        //        education.Name = name;
        //        await _context.SaveChangesAsync();
        //    }
        //    return education;
        //}
        //public async Task<Education> UpdateColorAsync(int id, string color)
        //{
        //    var education = await _context.Educations.Update(id);

        //    if (education == null)
        //    {
        //        throw new NotFoundException("Data not found");

        //    }
        //    else
        //    {
        //        education.Color = color;
        //        await _context.SaveChangesAsync();
        //    }
        //    return education;

        //}
    }
}
