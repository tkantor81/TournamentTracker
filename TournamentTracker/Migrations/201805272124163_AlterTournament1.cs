namespace TournamentTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTournament1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tournaments", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Tournaments", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tournaments", "Location");
            DropColumn("dbo.Tournaments", "Name");
        }
    }
}
