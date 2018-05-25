namespace TournamentTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterPeople : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Email", c => c.String());
            AlterColumn("dbo.People", "LastName", c => c.String());
        }
    }
}
