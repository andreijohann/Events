namespace Events.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Alias = c.String(nullable: false, maxLength: 25),
                        DthCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Alias, unique: true);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ShortDescription = c.String(nullable: false, maxLength: 200),
                        DetailedDescription = c.String(maxLength: 1000),
                        DthEvent = c.DateTime(nullable: false),
                        DthCreated = c.DateTime(nullable: false),
                        SourceId = c.Long(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Sources", t => t.SourceId, cascadeDelete: true)
                .Index(t => t.SourceId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SourceRegistry = c.Long(nullable: false),
                        SourceName = c.String(nullable: false, maxLength: 300),
                        SourceType = c.Byte(nullable: false),
                        DthCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.SourceRegistry, t.SourceType }, unique: true, name: "IX_SOURCETYPE_REGISTRY");
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.EventTags",
                c => new
                    {
                        EventId = c.Long(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventId, t.TagId })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.EventTags", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "SourceId", "dbo.Sources");
            DropForeignKey("dbo.Events", "CategoryId", "dbo.Categories");
            DropIndex("dbo.EventTags", new[] { "TagId" });
            DropIndex("dbo.EventTags", new[] { "EventId" });
            DropIndex("dbo.Tags", new[] { "Name" });
            DropIndex("dbo.Sources", "IX_SOURCETYPE_REGISTRY");
            DropIndex("dbo.Events", new[] { "CategoryId" });
            DropIndex("dbo.Events", new[] { "SourceId" });
            DropIndex("dbo.Categories", new[] { "Alias" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropTable("dbo.EventTags");
            DropTable("dbo.Tags");
            DropTable("dbo.Sources");
            DropTable("dbo.Events");
            DropTable("dbo.Categories");
        }
    }
}
