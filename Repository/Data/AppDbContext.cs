using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Education> Educations { get; set; }

        public DbSet<Group> Groups  { get; set; }

        public DbSet<User> Users  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3F8EQGP\\SQLEXPRESS;Database=EF-CourseAppDbContext;Trusted_Connection=true; TrustServerCertificate=True");
        }
    }
}
