namespace FoosballApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "TournamentWins", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "MatchPlayed", c => c.Int(nullable: false));
            DropColumn("dbo.Players", "PersonalWins");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "PersonalWins", c => c.Int(nullable: false));
            DropColumn("dbo.Players", "MatchPlayed");
            DropColumn("dbo.Players", "TournamentWins");
        }
    }
}
