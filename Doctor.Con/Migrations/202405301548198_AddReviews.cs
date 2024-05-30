namespace Doctor.Con.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        TargetReview = c.Byte(nullable: false),
                        Text = c.String(),
                        Rating = c.Double(nullable: false),
                        ClinicId = c.Int(),
                        DoctorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Clinics", t => t.ClinicId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ClinicId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Reviews", "ClinicId", "dbo.Clinics");
            DropForeignKey("dbo.Reviews", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "DoctorId" });
            DropIndex("dbo.Reviews", new[] { "ClinicId" });
            DropIndex("dbo.Reviews", new[] { "ApplicationUserId" });
            DropTable("dbo.Reviews");
        }
    }
}
