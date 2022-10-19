using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduMinAPI.Data
{
    public class EduMinContext : DbContext
    {
        public EduMinContext(DbContextOptions<EduMinContext> options) : base(options)
        { }

        public DbSet<EduMinAPI.Models.Students> EduMinDB { get; set; }
    }
}
