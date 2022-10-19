using Microsoft.EntityFrameworkCore;

namespace MinestryofInteriorAffairsAPI.Data
{
    public class MinestryofInteriorAffairsContext : DbContext
    {
        public MinestryofInteriorAffairsContext(DbContextOptions<MinestryofInteriorAffairsContext> options) : base(options)
        { }

        public DbSet<MinestryofInteriorAffairs.Model.MinestryofInteriorAffairsAPI> MinestryofInteriorAffairsDB { get; set; }
    }
}
