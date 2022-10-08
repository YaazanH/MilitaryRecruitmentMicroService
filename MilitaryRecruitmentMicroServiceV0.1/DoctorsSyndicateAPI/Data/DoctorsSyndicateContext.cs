using Microsoft.EntityFrameworkCore;


namespace DoctorsSyndicateAPI.Data
{
    public class DoctorsSyndicateContext : DbContext
    {
        public DoctorsSyndicateContext(DbContextOptions<DoctorsSyndicateContext> options) : base(options)
        { }

        public DbSet<DoctorsSyndicateAPI.Models.ClinicConfirmation> DoctorsSyndicateDb { get; set; }
    }
}
