namespace TournamentTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTournament2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tournaments", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tournaments", "State");
        }
    }
}
