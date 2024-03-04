namespace DbClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TypeEntities", newName: "TypeEventEntities");
            DropIndex("dbo.PatientEntities", new[] { "gender_Id" });
            CreateTable(
                "dbo.GovEntities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.PatientEntities", "snils", c => c.String());
            AddColumn("dbo.PatientEntities", "gov_id", c => c.Int());
            AddColumn("dbo.DiagnosisEntities", "recomendationDiagnosis", c => c.String());
            AddColumn("dbo.DiagnosisEntities", "anamnes", c => c.String());
            AddColumn("dbo.DiagnosisEntities", "symptoms", c => c.String());
            CreateIndex("dbo.PatientEntities", "gender_id");
            CreateIndex("dbo.PatientEntities", "gov_id");
            AddForeignKey("dbo.PatientEntities", "gov_id", "dbo.GovEntities", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientEntities", "gov_id", "dbo.GovEntities");
            DropIndex("dbo.PatientEntities", new[] { "gov_id" });
            DropIndex("dbo.PatientEntities", new[] { "gender_id" });
            DropColumn("dbo.DiagnosisEntities", "symptoms");
            DropColumn("dbo.DiagnosisEntities", "anamnes");
            DropColumn("dbo.DiagnosisEntities", "recomendationDiagnosis");
            DropColumn("dbo.PatientEntities", "gov_id");
            DropColumn("dbo.PatientEntities", "snils");
            DropTable("dbo.GovEntities");
            CreateIndex("dbo.PatientEntities", "gender_Id");
            RenameTable(name: "dbo.TypeEventEntities", newName: "TypeEntities");
        }
    }
}
