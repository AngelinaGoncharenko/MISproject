namespace DbClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ficsated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleEntities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.BedEntities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        roomNumber = c.Int(nullable: false),
                        bedCode = c.String(),
                        patient_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PatientEntities", t => t.patient_id)
                .Index(t => t.patient_id);
            
            AddColumn("dbo.AccountEntities", "role_id", c => c.Int());
            CreateIndex("dbo.AccountEntities", "role_id");
            AddForeignKey("dbo.AccountEntities", "role_id", "dbo.RoleEntities", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BedEntities", "patient_id", "dbo.PatientEntities");
            DropForeignKey("dbo.AccountEntities", "role_id", "dbo.RoleEntities");
            DropIndex("dbo.BedEntities", new[] { "patient_id" });
            DropIndex("dbo.AccountEntities", new[] { "role_id" });
            DropColumn("dbo.AccountEntities", "role_id");
            DropTable("dbo.BedEntities");
            DropTable("dbo.RoleEntities");
        }
    }
}
