using Microsoft.EntityFrameworkCore;

namespace UniversityAPI.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        { }

        public DbSet<UniversityAPI.Models.Student> UniversityDb { get; set; }
    }
}
