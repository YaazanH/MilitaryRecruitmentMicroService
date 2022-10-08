using Microsoft.EntityFrameworkCore;

namespace CivilPoliceAPI.Data
{
    public class CivilPoliceContext : DbContext
    {
        public CivilPoliceContext(DbContextOptions<CivilPoliceContext> options) : base(options)
        { }

        public DbSet<CivilPoliceAPI.Models.Person> CivilPoliceDb { get; set; }
    }
}
