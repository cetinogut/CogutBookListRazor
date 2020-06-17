using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CogutBookListRazor.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // empty conts.. but the parameter is needed for dependency injenction
        }

        public DbSet<Book> Books { get; set; }
    }
}
