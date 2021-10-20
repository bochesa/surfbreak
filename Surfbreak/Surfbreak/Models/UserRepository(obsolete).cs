using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surfbreak.Models
{
    public class UserRepository : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserRepository(DbContextOptions<UserRepository> options)
            : base (options)
        {
            Database.EnsureCreated();
        }
    }
}
