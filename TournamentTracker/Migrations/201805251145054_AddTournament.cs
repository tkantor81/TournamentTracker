namespace TournamentTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTournament : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TierID = c.Int(nullable: false),
                        StructureID = c.Int(nullable: false),
                        FormatID = c.Int(nullable: false),
                        RoundCount = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Formats", t => t.FormatID, cascadeDelete: true)
                .ForeignKey("dbo.Structures", t => t.StructureID, cascadeDelete: true)
                .ForeignKey("dbo.Tiers", t => t.TierID, cascadeDelete: true)
                .Index(t => t.TierID)
                .Index(t => t.StructureID)
                .Index(t => t.FormatID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tournaments", "TierID", "dbo.Tiers");
            DropForeignKey("dbo.Tournaments", "StructureID", "dbo.Structures");
            DropForeignKey("dbo.Tournaments", "FormatID", "dbo.Formats");
            DropIndex("dbo.Tournaments", new[] { "FormatID" });
            DropIndex("dbo.Tournaments", new[] { "StructureID" });
            DropIndex("dbo.Tournaments", new[] { "TierID" });
            DropTable("dbo.Tournaments");
        }
    }
}
