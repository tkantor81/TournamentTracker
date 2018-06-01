namespace TournamentTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMatches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoundID = c.Int(nullable: false),
                        Player1ID = c.Int(nullable: false),
                        Score1 = c.Int(nullable: false),
                        Player2ID = c.Int(nullable: false),
                        Score2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rounds", t => t.RoundID, cascadeDelete: true)
                .ForeignKey("dbo.Participants", t => t.Player1ID)
                .ForeignKey("dbo.Participants", t => t.Player2ID)
                .Index(t => t.RoundID)
                .Index(t => t.Player1ID)
                .Index(t => t.Player2ID);
            
            AddColumn("dbo.Rounds", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "Player2ID", "dbo.Participants");
            DropForeignKey("dbo.Matches", "Player1ID", "dbo.Participants");
            DropForeignKey("dbo.Matches", "RoundID", "dbo.Rounds");
            DropIndex("dbo.Matches", new[] { "Player2ID" });
            DropIndex("dbo.Matches", new[] { "Player1ID" });
            DropIndex("dbo.Matches", new[] { "RoundID" });
            DropColumn("dbo.Rounds", "State");
            DropTable("dbo.Matches");
        }
    }
}
