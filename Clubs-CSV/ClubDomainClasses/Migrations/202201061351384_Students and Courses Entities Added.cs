namespace ClubDomainClasses.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class StudentsandCoursesEntitiesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                {
                    StudentID = c.String(nullable: false, maxLength: 128),
                    FirstName = c.String(),
                    CourseID = c.Int(),
                    SecondName = c.String(),
                })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .Index(t => t.CourseID);

            CreateTable(
                "dbo.Courses",
                c => new
                {
                    CourseID = c.Int(nullable: false, identity: true),
                    CourseCode = c.String(),
                    Year = c.String(),
                    CourseName = c.String(),
                })
                .PrimaryKey(t => t.CourseID);

            AlterColumn("dbo.Member", "StudentID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Member", "StudentID");
            AddForeignKey("dbo.Member", "StudentID", "dbo.Student", "StudentID");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Member", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Student", "CourseID", "dbo.Courses");
            DropIndex("dbo.Student", new[] { "CourseID" });
            DropIndex("dbo.Member", new[] { "StudentID" });
            AlterColumn("dbo.Member", "StudentID", c => c.String());
            DropTable("dbo.Courses");
            DropTable("dbo.Student");
        }
    }
}
