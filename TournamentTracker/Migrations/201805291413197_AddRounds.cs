namespace TournamentTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRounds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TournamentID = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tournaments", t => t.TournamentID, cascadeDelete: true)
                .Index(t => t.TournamentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rounds", "TournamentID", "dbo.Tournaments");
            DropIndex("dbo.Rounds", new[] { "TournamentID" });
            DropTable("dbo.Rounds");
        }
    }
}
