using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtAPI.Data
{
   
        public class CourtContext : DbContext
        {
            public CourtContext(DbContextOptions<CourtContext> options) : base(options)
            { }

            public DbSet<CourtAPI.Models.Court> CourtDBS { get; set; }
        }
    
}
