namespace AppartmentSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SABINA.Appartments",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        StreetId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        HouseNumber = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Building = c.String(),
                        Flat = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SABINA.Streets", t => t.StreetId, cascadeDelete: true)
                .Index(t => t.StreetId);
            
            CreateTable(
                "SABINA.OwningsTable",
                c => new
                    {
                        OwnerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        AppartmentId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        DateStartOwning = c.DateTime(nullable: false),
                        DateFinishOwning = c.DateTime(),
                        ShareOwning = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.OwnerId, t.AppartmentId })
                .ForeignKey("SABINA.Appartments", t => t.AppartmentId, cascadeDelete: true)
                .ForeignKey("SABINA.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.AppartmentId);
            
            CreateTable(
                "SABINA.Owners",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        MiddleName = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        Gender = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DocumentId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        DocumentSerial = c.String(nullable: false),
                        DocumentNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SABINA.TypeDocuments", t => t.DocumentId, cascadeDelete: true)
                .Index(t => t.DocumentId);
            
            CreateTable(
                "SABINA.TypeDocuments",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "SABINA.Streets",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Title = c.String(nullable: false),
                        AreaId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SABINA.Areas", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);
            
            CreateTable(
                "SABINA.Areas",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("SABINA.Appartments", "StreetId", "SABINA.Streets");
            DropForeignKey("SABINA.Streets", "AreaId", "SABINA.Areas");
            DropForeignKey("SABINA.OwningsTable", "OwnerId", "SABINA.Owners");
            DropForeignKey("SABINA.Owners", "DocumentId", "SABINA.TypeDocuments");
            DropForeignKey("SABINA.OwningsTable", "AppartmentId", "SABINA.Appartments");
            DropIndex("SABINA.Streets", new[] { "AreaId" });
            DropIndex("SABINA.Owners", new[] { "DocumentId" });
            DropIndex("SABINA.OwningsTable", new[] { "AppartmentId" });
            DropIndex("SABINA.OwningsTable", new[] { "OwnerId" });
            DropIndex("SABINA.Appartments", new[] { "StreetId" });
            DropTable("SABINA.Areas");
            DropTable("SABINA.Streets");
            DropTable("SABINA.TypeDocuments");
            DropTable("SABINA.Owners");
            DropTable("SABINA.OwningsTable");
            DropTable("SABINA.Appartments");
        }
    }
}
