namespace FoosballApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Result = c.Int(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        AScore = c.Int(nullable: false),
                        BScore = c.Int(nullable: false),
                        TeamA_Id = c.Int(),
                        TeamB_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamA_Id)
                .ForeignKey("dbo.Teams", t => t.TeamB_Id)
                .Index(t => t.TeamA_Id)
                .Index(t => t.TeamB_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MatchWins = c.Int(nullable: false),
                        TournamentWins = c.Int(nullable: false),
                        MatchesPlayed = c.Int(nullable: false),
                        PlayerA_Id = c.Int(),
                        PlayerB_Id = c.Int(),
                        Tournament_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerA_Id)
                .ForeignKey("dbo.Players", t => t.PlayerB_Id)
                .ForeignKey("dbo.Tournaments", t => t.Tournament_Id)
                .Index(t => t.PlayerA_Id)
                .Index(t => t.PlayerB_Id)
                .Index(t => t.Tournament_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MatchWins = c.Int(nullable: false),
                        TournamentWins = c.Int(nullable: false),
                        MatchPlayed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Round = c.Int(nullable: false),
                        Winner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Winner_Id)
                .Index(t => t.Winner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tournaments", "Winner_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Tournament_Id", "dbo.Tournaments");
            DropForeignKey("dbo.Matches", "TeamB_Id", "dbo.Teams");
            DropForeignKey("dbo.Matches", "TeamA_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "PlayerB_Id", "dbo.Players");
            DropForeignKey("dbo.Teams", "PlayerA_Id", "dbo.Players");
            DropIndex("dbo.Tournaments", new[] { "Winner_Id" });
            DropIndex("dbo.Teams", new[] { "Tournament_Id" });
            DropIndex("dbo.Teams", new[] { "PlayerB_Id" });
            DropIndex("dbo.Teams", new[] { "PlayerA_Id" });
            DropIndex("dbo.Matches", new[] { "TeamB_Id" });
            DropIndex("dbo.Matches", new[] { "TeamA_Id" });
            DropTable("dbo.Tournaments");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
        }
    }
}
