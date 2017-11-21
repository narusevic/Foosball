namespace FoosballApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MatchWins = c.Int(nullable: false),
                        TournamentWins = c.Int(nullable: false),
                        MatchesPlayed = c.Int(nullable: false),
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
                .ForeignKey("dbo.Players", t => t.Winner_Id)
                .Index(t => t.Winner_Id);
            
            AddColumn("dbo.Players", "MatchWins", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "PersonalWins", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "Team_Id", c => c.Int());
            AddColumn("dbo.Players", "Tournament_Id", c => c.Int());
            CreateIndex("dbo.Players", "Team_Id");
            CreateIndex("dbo.Players", "Tournament_Id");
            AddForeignKey("dbo.Players", "Team_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.Players", "Tournament_Id", "dbo.Tournaments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tournaments", "Winner_Id", "dbo.Players");
            DropForeignKey("dbo.Players", "Tournament_Id", "dbo.Tournaments");
            DropForeignKey("dbo.Players", "Team_Id", "dbo.Teams");
            DropIndex("dbo.Tournaments", new[] { "Winner_Id" });
            DropIndex("dbo.Players", new[] { "Tournament_Id" });
            DropIndex("dbo.Players", new[] { "Team_Id" });
            DropColumn("dbo.Players", "Tournament_Id");
            DropColumn("dbo.Players", "Team_Id");
            DropColumn("dbo.Players", "PersonalWins");
            DropColumn("dbo.Players", "MatchWins");
            DropTable("dbo.Tournaments");
            DropTable("dbo.Teams");
        }
    }
}
