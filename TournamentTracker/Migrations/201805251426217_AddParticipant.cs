namespace TournamentTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParticipant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonID = c.Int(nullable: false),
                        TournamentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Tournaments", t => t.TournamentID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.TournamentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "TournamentID", "dbo.Tournaments");
            DropForeignKey("dbo.Participants", "PersonID", "dbo.People");
            DropIndex("dbo.Participants", new[] { "TournamentID" });
            DropIndex("dbo.Participants", new[] { "PersonID" });
            DropTable("dbo.Participants");
        }
    }
}
