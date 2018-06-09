using InvestmentTracker.Core.Entities;
using System.Data.Entity;

namespace InvestmentTracker.Core
{
    public class InvestmentTrackerDbContext : DbContext
    {
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FundPurchased>().Property(x => x.AmountInvested).HasPrecision(18, 4);
            modelBuilder.Entity<FundPurchased>().Property(x => x.NavPurchasePrice).HasPrecision(18, 4);
            modelBuilder.Entity<FundPurchased>().Property(x => x.NavsPurchased).HasPrecision(18, 4);
            modelBuilder.Entity<LatestNavPrice>().Property(x => x.NavPrice).HasPrecision(18, 4);
            modelBuilder.Entity<CurrencyPrice>().Property(x => x.Price).HasPrecision(18, 4);
            base.OnModelCreating(modelBuilder);
        }

        public InvestmentTrackerDbContext() : base("InvestmentTracker")
        { }
        public DbSet<FundPurchased> FundPurchased { get; set; }
        public DbSet<LatestNavPrice> LatestNavPrice { get; set; }
        public DbSet<CurrencyPrice> CurrencyPrice { get; set; }
    }
}