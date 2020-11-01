namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.tblSemesters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(nullable: false, maxLength: 50),
                        Duration = c.Int(nullable: false),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SemesterId)
                .ForeignKey("dbo.tblStudents", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.tblStudents",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                        ImageName = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblSemesters", "StudentId", "dbo.tblStudents");
            DropForeignKey("dbo.tblRoles", "UserId", "dbo.tblUsers");
            DropIndex("dbo.tblSemesters", new[] { "StudentId" });
            DropIndex("dbo.tblRoles", new[] { "UserId" });
            DropTable("dbo.tblStudents");
            DropTable("dbo.tblSemesters");
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblRoles");
        }
    }
}
