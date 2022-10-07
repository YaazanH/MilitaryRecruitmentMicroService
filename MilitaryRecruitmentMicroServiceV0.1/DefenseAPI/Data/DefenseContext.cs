using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefenseAPI.Data
{
    public class DefenseContext :DbContext
    {
        public DefenseContext(DbContextOptions<DefenseContext> options) : base(options)
        { }

        public DbSet<DefenseAPI.Models.Defense> DefensesDBS { get; set; }
    }
}
