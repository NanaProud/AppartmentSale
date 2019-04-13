namespace AppartmentSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SYSTEM.Appartments",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        StreetId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        HouseNumber = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Building = c.String(),
                        Flat = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SYSTEM.Streets", t => t.StreetId, cascadeDelete: true)
                .Index(t => t.StreetId);
            
            CreateTable(
                "SYSTEM.OwningsTable",
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
                .ForeignKey("SYSTEM.Appartments", t => t.AppartmentId, cascadeDelete: true)
                .ForeignKey("SYSTEM.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.AppartmentId);
            
            CreateTable(
                "SYSTEM.Owners",
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
                .ForeignKey("SYSTEM.TypeDocuments", t => t.DocumentId, cascadeDelete: true)
                .Index(t => t.DocumentId);
            
            CreateTable(
                "SYSTEM.TypeDocuments",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "SYSTEM.Streets",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Title = c.String(nullable: false),
                        AreaId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SYSTEM.Areas", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);
            
            CreateTable(
                "SYSTEM.Areas",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Ttile = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("SYSTEM.Appartments", "StreetId", "SYSTEM.Streets");
            DropForeignKey("SYSTEM.Streets", "AreaId", "SYSTEM.Areas");
            DropForeignKey("SYSTEM.OwningsTable", "OwnerId", "SYSTEM.Owners");
            DropForeignKey("SYSTEM.Owners", "DocumentId", "SYSTEM.TypeDocuments");
            DropForeignKey("SYSTEM.OwningsTable", "AppartmentId", "SYSTEM.Appartments");
            DropIndex("SYSTEM.Streets", new[] { "AreaId" });
            DropIndex("SYSTEM.Owners", new[] { "DocumentId" });
            DropIndex("SYSTEM.OwningsTable", new[] { "AppartmentId" });
            DropIndex("SYSTEM.OwningsTable", new[] { "OwnerId" });
            DropIndex("SYSTEM.Appartments", new[] { "StreetId" });
            DropTable("SYSTEM.Areas");
            DropTable("SYSTEM.Streets");
            DropTable("SYSTEM.TypeDocuments");
            DropTable("SYSTEM.Owners");
            DropTable("SYSTEM.OwningsTable");
            DropTable("SYSTEM.Appartments");
        }
    }
}
