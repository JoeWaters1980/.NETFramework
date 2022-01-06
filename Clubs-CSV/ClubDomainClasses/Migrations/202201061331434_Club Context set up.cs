namespace ClubDomainClasses.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ClubContextsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClubEvent",
                c => new
                {
                    EventID = c.Int(nullable: false, identity: true),
                    Venue = c.String(),
                    Location = c.String(),
                    ClubId = c.Int(nullable: false),
                    StartDateTime = c.DateTime(nullable: false),
                    EndDateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Club", t => t.ClubId, cascadeDelete: true)
                .Index(t => t.ClubId);

            CreateTable(
                "dbo.Club",
                c => new
                {
                    ClubId = c.Int(nullable: false, identity: true),
                    ClubName = c.String(),
                    CreationDate = c.DateTime(nullable: false, storeType: "date"),
                    AdminID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ClubId);

            CreateTable(
                "dbo.Member",
                c => new
                {
                    MemberID = c.Int(nullable: false, identity: true),
                    AssociatedClub = c.Int(nullable: false),
                    StudentID = c.String(),
                    Approved = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.MemberID)
                .ForeignKey("dbo.Club", t => t.AssociatedClub, cascadeDelete: true)
                .Index(t => t.AssociatedClub);

            CreateTable(
                "dbo.EventAttendance",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    EventID = c.Int(nullable: false),
                    AttendeeMember = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ClubEvent", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.AttendeeMember)
                .Index(t => t.EventID)
                .Index(t => t.AttendeeMember);

        }

        public override void Down()
        {
            DropForeignKey("dbo.EventAttendance", "AttendeeMember", "dbo.Member");
            DropForeignKey("dbo.EventAttendance", "EventID", "dbo.ClubEvent");
            DropForeignKey("dbo.ClubEvent", "ClubId", "dbo.Club");
            DropForeignKey("dbo.Member", "AssociatedClub", "dbo.Club");
            DropIndex("dbo.EventAttendance", new[] { "AttendeeMember" });
            DropIndex("dbo.EventAttendance", new[] { "EventID" });
            DropIndex("dbo.Member", new[] { "AssociatedClub" });
            DropIndex("dbo.ClubEvent", new[] { "ClubId" });
            DropTable("dbo.EventAttendance");
            DropTable("dbo.Member");
            DropTable("dbo.Club");
            DropTable("dbo.ClubEvent");
        }
    }
}
