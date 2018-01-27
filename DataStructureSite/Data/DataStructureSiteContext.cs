using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataStructureSite.Models
{
    public class DataStructureSiteContext : DbContext
    {
        public DataStructureSiteContext (DbContextOptions<DataStructureSiteContext> options)
            : base(options)
        {
        }

        public DbSet<DataStructureSite.Models.Datastructure> Datastructure { get; set; }
    }
}
