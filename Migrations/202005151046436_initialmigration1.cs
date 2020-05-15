namespace zaynabLara_homework4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckingAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(nullable: false, maxLength: 10, unicode: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckingAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckingAccounts", t => t.CheckingAccountId, cascadeDelete: true)
                .Index(t => t.CheckingAccountId);
            
            AddColumn("dbo.AspNetUsers", "Pin", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckingAccounts", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "CheckingAccountId", "dbo.CheckingAccounts");
            DropIndex("dbo.Transactions", new[] { "CheckingAccountId" });
            DropIndex("dbo.CheckingAccounts", new[] { "ApplicationUserId" });
            DropColumn("dbo.AspNetUsers", "Pin");
            DropTable("dbo.Transactions");
            DropTable("dbo.CheckingAccounts");
        }
    }
}
