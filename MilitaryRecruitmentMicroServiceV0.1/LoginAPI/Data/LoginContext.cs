using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Data
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options) : base(options)
        { }

        public DbSet<LoginAPI.Models.Login> HighEduMinDBS { get; set; }
    }
}
