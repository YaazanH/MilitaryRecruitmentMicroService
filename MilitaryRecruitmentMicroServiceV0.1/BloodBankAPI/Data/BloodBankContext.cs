using Microsoft.EntityFrameworkCore;

namespace BloodBankAPI.Data
{
    public class BloodBankContext : DbContext
    {
        public BloodBankContext(DbContextOptions<BloodBankContext> options) : base(options)
        { }

        public DbSet<BloodBankAPI.Models.DonationCard> BloodBankDb { get; set; }
    }
}
