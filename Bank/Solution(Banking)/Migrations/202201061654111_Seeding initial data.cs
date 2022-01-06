namespace Solution_Banking_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seedinginitialdata : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "AccountID", "dbo.Account");
            DropPrimaryKey("dbo.Account");
            AddColumn("dbo.Account", "AccountID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Account", "AccountID");
            AddForeignKey("dbo.Transactions", "AccountID", "dbo.Account", "AccountID", cascadeDelete: true);
            DropColumn("dbo.Account", "AcccountID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Account", "AcccountID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Transactions", "AccountID", "dbo.Account");
            DropPrimaryKey("dbo.Account");
            DropColumn("dbo.Account", "AccountID");
            AddPrimaryKey("dbo.Account", "AcccountID");
            AddForeignKey("dbo.Transactions", "AccountID", "dbo.Account", "AcccountID", cascadeDelete: true);
        }
    }
}
