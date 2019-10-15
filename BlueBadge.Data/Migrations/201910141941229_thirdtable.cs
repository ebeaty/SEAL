namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medical",
                c => new
                    {
                        MedicalId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        FinancialAid = c.Boolean(nullable: false),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.MedicalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medical");
        }
    }
}
