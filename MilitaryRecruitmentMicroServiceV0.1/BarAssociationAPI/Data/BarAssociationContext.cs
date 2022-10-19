using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BarAssociationAPI.Data
{
    public class BarAssociationContext : DbContext
    {
        public BarAssociationContext(DbContextOptions<BarAssociationContext> options) : base(options)
        { }

        public DbSet<BarAssociationAPI.Models.Lawyers> BarAssociationDB { get; set; }
    }
}
