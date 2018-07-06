namespace TournamentTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterMatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participants", "Discriminator");
        }
    }
}
