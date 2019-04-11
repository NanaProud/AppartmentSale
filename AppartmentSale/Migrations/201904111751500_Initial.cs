namespace AppartmentSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SYSTEM.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "SYSTEM.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("SYSTEM.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("SYSTEM.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "SYSTEM.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Decimal(nullable: false, precision: 1, scale: 0),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Decimal(nullable: false, precision: 1, scale: 0),
                        TwoFactorEnabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        AccessFailedCount = c.Decimal(nullable: false, precision: 10, scale: 0),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "SYSTEM.AspNetUserClaims",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SYSTEM.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "SYSTEM.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("SYSTEM.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("SYSTEM.AspNetUserRoles", "UserId", "SYSTEM.AspNetUsers");
            DropForeignKey("SYSTEM.AspNetUserLogins", "UserId", "SYSTEM.AspNetUsers");
            DropForeignKey("SYSTEM.AspNetUserClaims", "UserId", "SYSTEM.AspNetUsers");
            DropForeignKey("SYSTEM.AspNetUserRoles", "RoleId", "SYSTEM.AspNetRoles");
            DropIndex("SYSTEM.AspNetUserLogins", new[] { "UserId" });
            DropIndex("SYSTEM.AspNetUserClaims", new[] { "UserId" });
            DropIndex("SYSTEM.AspNetUsers", "UserNameIndex");
            DropIndex("SYSTEM.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("SYSTEM.AspNetUserRoles", new[] { "UserId" });
            DropIndex("SYSTEM.AspNetRoles", "RoleNameIndex");
            DropTable("SYSTEM.AspNetUserLogins");
            DropTable("SYSTEM.AspNetUserClaims");
            DropTable("SYSTEM.AspNetUsers");
            DropTable("SYSTEM.AspNetUserRoles");
            DropTable("SYSTEM.AspNetRoles");
        }
    }
}
