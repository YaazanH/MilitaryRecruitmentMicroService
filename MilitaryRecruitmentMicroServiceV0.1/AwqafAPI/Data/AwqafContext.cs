using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwqafAPI.Data
{
    public class AwqafContext:DbContext
    {
        public AwqafContext(DbContextOptions<AwqafContext> options) : base(options)
        { }

        public DbSet<AwqafAPI.Models.Awqaf> AwqafDBS { get; set; }
    }
}
