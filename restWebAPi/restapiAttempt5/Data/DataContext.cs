using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using restapiAttempt5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapiAttempt5.Data
{

    //used for data manipulation
    public class DataContext : IdentityDbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        //represents table
        public DbSet<Post> Posts { get; set; }  


    }
}
