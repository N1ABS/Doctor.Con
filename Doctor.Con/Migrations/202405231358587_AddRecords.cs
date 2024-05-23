namespace Doctor.Con.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        RecordDate = c.DateTime(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Records", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Records", new[] { "DoctorId" });
            DropIndex("dbo.Records", new[] { "PatientId" });
            DropTable("dbo.Records");
        }
    }
}
