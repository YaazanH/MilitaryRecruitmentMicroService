using Microsoft.EntityFrameworkCore;

namespace PassportAPI.Data
{
    public class PassportContext : DbContext
    {
        public PassportContext(DbContextOptions<PassportContext> options) : base(options)
        { }

        public DbSet<PassportAPI.Model.Passport> PassportDBS { get; set; }
    }
}