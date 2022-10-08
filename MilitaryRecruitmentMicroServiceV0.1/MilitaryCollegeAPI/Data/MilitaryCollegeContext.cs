using Microsoft.EntityFrameworkCore;

namespace MilitaryCollegeAPI.Data
{
    public class MilitiryCollegeContext : DbContext
    {
        public MilitiryCollegeContext(DbContextOptions<MilitiryCollegeContext> options) : base(options)
        { }

        public DbSet<MilitaryCollegeAPI.Models.Solider> MilitiryCollegeDb { get; set; }
    }
}
