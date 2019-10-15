namespace BlueBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTableSuccess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupportGroup",
                c => new
                    {
                        SupportGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.SupportGroupId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SupportGroup");
        }
    }
}
