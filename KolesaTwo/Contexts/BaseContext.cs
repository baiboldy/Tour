using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolesaTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace KolesaTwo.Contexts {
    public class BaseContext : DbContext {
        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options) {
        }

        public DbSet<Tour> Tour { get; set; }
        public DbSet<Guide> Guide { get; set; }
        public DbSet<Place> Place { get; set; }
    }
}
