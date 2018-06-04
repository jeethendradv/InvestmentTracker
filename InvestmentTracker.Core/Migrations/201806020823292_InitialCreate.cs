namespace InvestmentTracker.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FundPurchaseds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchemeCode = c.String(),
                        Name = c.String(),
                        NavPurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 4),
                        PurchaseDate = c.DateTime(nullable: false),
                        NavsPurchased = c.Decimal(precision: 18, scale: 4),
                        AmountInvested = c.Decimal(precision: 18, scale: 4),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LatestNavPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchemeCode = c.String(),
                        NavPrice = c.Decimal(nullable: false, precision: 18, scale: 4),
                        Date = c.DateTime(nullable: false),
                        LastFetch = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LatestNavPrices");
            DropTable("dbo.FundPurchaseds");
        }
    }
}
