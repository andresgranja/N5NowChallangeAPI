using Microsoft.EntityFrameworkCore;
using N5Now.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Fluent API configurations go here...
    }
}
