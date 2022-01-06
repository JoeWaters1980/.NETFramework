namespace Solution_Banking_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        InceptionDate = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        CurrentBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Account Type",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Conditions = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TransactionType = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionDate = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountID", "dbo.Account");
            DropForeignKey("dbo.Account", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Transactions", new[] { "AccountID" });
            DropIndex("dbo.Account", new[] { "CustomerID" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Account Type");
            DropTable("dbo.Customer");
            DropTable("dbo.Account");
        }
    }
}
