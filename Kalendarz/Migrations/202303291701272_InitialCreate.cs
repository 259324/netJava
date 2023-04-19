namespace Kalendarz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddToCalendars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        EventDescription = c.String(),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AddToCalendars");
        }
    }
}
