using Microsoft.EntityFrameworkCore;

namespace MilitaryCollegeAPI.Data
{
    public class MilitaryCollegeContext : DbContext
    {
        public MilitaryCollegeContext(DbContextOptions<MilitaryCollegeContext> options) : base(options)
        { }

        public DbSet<MilitaryCollegeAPI.Models.MilitaryCollege> MilitaryCollegeDBS { get; set; }
    }
}