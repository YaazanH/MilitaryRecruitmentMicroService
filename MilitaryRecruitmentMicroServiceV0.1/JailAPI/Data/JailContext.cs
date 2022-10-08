using Microsoft.EntityFrameworkCore;

namespace JailAPI.Data
{
    public class JailContext : DbContext
    {
        public JailContext(DbContextOptions<JailContext> options) : base(options)
        { }

        public DbSet<JailAPI.Models.Jail> JailDBS { get; set; }
    }
}