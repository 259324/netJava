namespace Kalendarz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Baza1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        EventDescription = c.String(),
                        Date = c.DateTime(nullable: false),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
