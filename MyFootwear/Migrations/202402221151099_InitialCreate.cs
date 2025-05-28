namespace MyFootwear.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProudctId = c.Int(nullable: false, identity: true),
                        ProuductName = c.String(),
                        BrandID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        Material = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Image = c.String(),
                        Availability = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProudctId)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.BrandID)
                .Index(t => t.TypeID)
                .Index(t => t.SellerId);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerId = c.Int(nullable: false, identity: true),
                        SellerName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 60),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 16),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SellerId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        TypesName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CartId);
            
            CreateTable(
                "dbo.RegCusts",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CName = c.String(nullable: false, maxLength: 60),
                        Email = c.String(nullable: false, maxLength: 80),
                        Password = c.String(nullable: false, maxLength: 16),
                        ConfirmPassword = c.String(nullable: false, maxLength: 16),
                        PrimaryMobile = c.String(nullable: false, maxLength: 10),
                        SecondaryMobile = c.String(nullable: false, maxLength: 10),
                        Shipping_Address = c.String(nullable: false, maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "TypeID", "dbo.Types");
            DropForeignKey("dbo.Products", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "SellerId" });
            DropIndex("dbo.Products", new[] { "TypeID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropTable("dbo.RegCusts");
            DropTable("dbo.Carts");
            DropTable("dbo.Types");
            DropTable("dbo.Sellers");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}
