namespace Doctor.Con.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        ProfessionId = c.Int(nullable: false),
                        ClinicId = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinics", t => t.ClinicId, cascadeDelete: true)
                .ForeignKey("dbo.Professions", t => t.ProfessionId, cascadeDelete: true)
                .Index(t => t.ProfessionId)
                .Index(t => t.ClinicId);
            
            CreateTable(
                "dbo.Professions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "ProfessionId", "dbo.Professions");
            DropForeignKey("dbo.Doctors", "ClinicId", "dbo.Clinics");
            DropIndex("dbo.Doctors", new[] { "ClinicId" });
            DropIndex("dbo.Doctors", new[] { "ProfessionId" });
            DropTable("dbo.Professions");
            DropTable("dbo.Doctors");
        }
    }
}
