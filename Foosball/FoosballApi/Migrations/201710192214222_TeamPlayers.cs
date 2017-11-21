namespace FoosballApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamPlayers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "Team_Id", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "Team_Id" });
            AddColumn("dbo.Teams", "PlayerA_Id", c => c.Int());
            AddColumn("dbo.Teams", "PlayerB_Id", c => c.Int());
            CreateIndex("dbo.Teams", "PlayerA_Id");
            CreateIndex("dbo.Teams", "PlayerB_Id");
            AddForeignKey("dbo.Teams", "PlayerA_Id", "dbo.Players", "Id");
            AddForeignKey("dbo.Teams", "PlayerB_Id", "dbo.Players", "Id");
            DropColumn("dbo.Players", "Team_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Team_Id", c => c.Int());
            DropForeignKey("dbo.Teams", "PlayerB_Id", "dbo.Players");
            DropForeignKey("dbo.Teams", "PlayerA_Id", "dbo.Players");
            DropIndex("dbo.Teams", new[] { "PlayerB_Id" });
            DropIndex("dbo.Teams", new[] { "PlayerA_Id" });
            DropColumn("dbo.Teams", "PlayerB_Id");
            DropColumn("dbo.Teams", "PlayerA_Id");
            CreateIndex("dbo.Players", "Team_Id");
            AddForeignKey("dbo.Players", "Team_Id", "dbo.Teams", "Id");
        }
    }
}
