namespace FoosballApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        PlayerA_Id = c.Int(),
                        PlayerB_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerA_Id)
                .ForeignKey("dbo.Players", t => t.PlayerB_Id)
                .Index(t => t.PlayerA_Id)
                .Index(t => t.PlayerB_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "PlayerB_Id", "dbo.Players");
            DropForeignKey("dbo.Matches", "PlayerA_Id", "dbo.Players");
            DropIndex("dbo.Matches", new[] { "PlayerB_Id" });
            DropIndex("dbo.Matches", new[] { "PlayerA_Id" });
            DropTable("dbo.Players");
            DropTable("dbo.Matches");
        }
    }
}
