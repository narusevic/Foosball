namespace Foosball.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teamsupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "PlayerA_Id", "dbo.Players");
            DropForeignKey("dbo.Matches", "PlayerB_Id", "dbo.Players");
            DropForeignKey("dbo.Players", "Tournament_Id", "dbo.Tournaments");
            DropIndex("dbo.Matches", new[] { "PlayerA_Id" });
            DropIndex("dbo.Matches", new[] { "PlayerB_Id" });
            DropIndex("dbo.Players", new[] { "Tournament_Id" });
            AddColumn("dbo.Matches", "TeamA_Id", c => c.Int());
            AddColumn("dbo.Matches", "TeamB_Id", c => c.Int());
            AddColumn("dbo.Teams", "Tournament_Id", c => c.Int());
            CreateIndex("dbo.Matches", "TeamA_Id");
            CreateIndex("dbo.Matches", "TeamB_Id");
            CreateIndex("dbo.Teams", "Tournament_Id");
            AddForeignKey("dbo.Matches", "TeamA_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.Matches", "TeamB_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.Teams", "Tournament_Id", "dbo.Tournaments", "Id");
            DropColumn("dbo.Matches", "PlayerA_Id");
            DropColumn("dbo.Matches", "PlayerB_Id");
            DropColumn("dbo.Players", "Tournament_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Tournament_Id", c => c.Int());
            AddColumn("dbo.Matches", "PlayerB_Id", c => c.Int());
            AddColumn("dbo.Matches", "PlayerA_Id", c => c.Int());
            DropForeignKey("dbo.Teams", "Tournament_Id", "dbo.Tournaments");
            DropForeignKey("dbo.Matches", "TeamB_Id", "dbo.Teams");
            DropForeignKey("dbo.Matches", "TeamA_Id", "dbo.Teams");
            DropIndex("dbo.Teams", new[] { "Tournament_Id" });
            DropIndex("dbo.Matches", new[] { "TeamB_Id" });
            DropIndex("dbo.Matches", new[] { "TeamA_Id" });
            DropColumn("dbo.Teams", "Tournament_Id");
            DropColumn("dbo.Matches", "TeamB_Id");
            DropColumn("dbo.Matches", "TeamA_Id");
            CreateIndex("dbo.Players", "Tournament_Id");
            CreateIndex("dbo.Matches", "PlayerB_Id");
            CreateIndex("dbo.Matches", "PlayerA_Id");
            AddForeignKey("dbo.Players", "Tournament_Id", "dbo.Tournaments", "Id");
            AddForeignKey("dbo.Matches", "PlayerB_Id", "dbo.Players", "Id");
            AddForeignKey("dbo.Matches", "PlayerA_Id", "dbo.Players", "Id");
        }
    }
}
