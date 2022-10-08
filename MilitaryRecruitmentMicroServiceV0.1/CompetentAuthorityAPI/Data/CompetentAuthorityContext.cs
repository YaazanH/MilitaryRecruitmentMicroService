using Microsoft.EntityFrameworkCore;

namespace CompetentAuthorityAPI.Data
{
    public class CompetentAuthorityContext : DbContext
    {
        public CompetentAuthorityContext(DbContextOptions<CompetentAuthorityContext> options) : base(options)
        { }

        public DbSet<CompetentAuthorityAPI.Models.CompetentAuthority> CompetentAuthorityDBS { get; set; }
    }
}