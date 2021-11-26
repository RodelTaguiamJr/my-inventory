using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FINAL_PROJECT.Models;

namespace FINAL_PROJECT.Data
{
    public class ApplicationDBContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :
            base(options)
        {

        }
        public DbSet<Business> Businesses { get; set; }

        public DbSet<Item> Items { get; set; }



    }
}
