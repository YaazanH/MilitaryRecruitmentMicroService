using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassportAPI.Data
{
    public class PassportContext : DbContext
    {
       
        
            public PassportContext(DbContextOptions<PassportContext> options) : base(options)
            { }

            public DbSet<PassportAPI.Models.Passport> PassportDBS { get; set; }
        
    }
}
