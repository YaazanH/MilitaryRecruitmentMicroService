using Microsoft.EntityFrameworkCore;

namespace MinistryOfForeignAffairsAPI.Data
{
    public class MinistryOfForeignAffairsContext : DbContext
    {
        public MinistryOfForeignAffairsContext(DbContextOptions<MinistryOfForeignAffairsContext> options) : base(options)
        { }

        public DbSet<MinistryOfForeignAffairsAPI.Models.MinistryOfForeignAffairs> MinistryOfForeignAffairsDB { get; set; }
    }
}
