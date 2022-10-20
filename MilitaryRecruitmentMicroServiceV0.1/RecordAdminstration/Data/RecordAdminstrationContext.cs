using Microsoft.EntityFrameworkCore;

namespace RecordAdminstrationAPI.Data
{
    public class RecordAdminstrationContext : DbContext
    {
        public RecordAdminstrationContext(DbContextOptions<RecordAdminstrationContext> options) : base(options)
        { }

        public DbSet<RecordAdminstrationAPI.Models.RecordsAdminstration> MinistryOfForeignAffairsDB { get; set; }
        public DbSet<RecordAdminstrationAPI.Models.Brothers> BrothersDB { get; set; }
    }
}
