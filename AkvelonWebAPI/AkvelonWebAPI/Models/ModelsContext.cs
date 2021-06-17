using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkvelonWebAPI.Models
{
    public class ModelsContext : DbContext
    {
        public DbSet<TaskModel> taskModels { get; set; }

        public DbSet<ProjectModel> projectModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AkvelonInternship;Trusted_Connection=True;");
        }
    }
}
