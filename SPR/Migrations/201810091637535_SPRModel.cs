namespace SPR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SPRModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Receivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        surname1 = c.String(),
                        surname2 = c.String(),
                        Email_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emails", t => t.Email_Id)
                .Index(t => t.Email_Id);
            
            CreateTable(
                "dbo.ServerPerformances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPU = c.Double(nullable: false),
                        RAM = c.Double(nullable: false),
                        IO_Disk = c.Double(nullable: false),
                        IIS_Sessions = c.Int(nullable: false),
                        Receiver_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Receivers", t => t.Receiver_Id)
                .Index(t => t.Receiver_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receivers", "Email_Id", "dbo.Emails");
            DropForeignKey("dbo.ServerPerformances", "Receiver_Id", "dbo.Receivers");
            DropIndex("dbo.ServerPerformances", new[] { "Receiver_Id" });
            DropIndex("dbo.Receivers", new[] { "Email_Id" });
            DropTable("dbo.ServerPerformances");
            DropTable("dbo.Receivers");
            DropTable("dbo.Emails");
        }
    }
}
