namespace Endeavour.ObserverContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17042014 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.References", newName: "WebApiReference");
            DropForeignKey("dbo.TopicRecordValueReferences", "ReferenceId", "dbo.References");
            DropIndex("dbo.TopicRecordValueReferences", new[] { "ReferenceId" });
            CreateIndex("dbo.WebApiReference", "ID");
            CreateIndex("dbo.TopicRecordValueReferences", "ReferenceId");
            AddForeignKey("dbo.WebApiReference", "ID", "dbo.References", "ID");
            AddForeignKey("dbo.TopicRecordValueReferences", "ReferenceId", "dbo.WebApiReference", "ID");
            DropColumn("dbo.References", "WebApiAddress");
            DropColumn("dbo.References", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.References", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.References", "WebApiAddress", c => c.String());
            DropForeignKey("dbo.TopicRecordValueReferences", "ReferenceId", "dbo.WebApiReference");
            DropForeignKey("dbo.WebApiReference", "ID", "dbo.References");
            DropIndex("dbo.TopicRecordValueReferences", new[] { "ReferenceId" });
            DropIndex("dbo.WebApiReference", new[] { "ID" });
            CreateIndex("dbo.TopicRecordValueReferences", "ReferenceId");
            AddForeignKey("dbo.TopicRecordValueReferences", "ReferenceId", "dbo.References", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.WebApiReference", newName: "References");
        }
    }
}
