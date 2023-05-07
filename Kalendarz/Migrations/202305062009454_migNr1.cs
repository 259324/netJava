namespace Kalendarz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migNr1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "Data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Data", c => c.String());
        }
    }
}
