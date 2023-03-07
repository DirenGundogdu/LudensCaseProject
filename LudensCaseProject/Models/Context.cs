using Microsoft.EntityFrameworkCore;

namespace LudensCaseProject.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Funds> Funds { get; set; }
        public DbSet<FundPrices> FundPrices { get; set; }
    }
}
