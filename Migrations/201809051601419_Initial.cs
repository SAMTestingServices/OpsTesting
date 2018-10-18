namespace Clarksons.Cloud.Logging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
			CreateTable(
				"dbo.TestRuns",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					ApplicationVersion = c.String(),
					Module = c.String(),
					Environment = c.String(),
				})
				.PrimaryKey(t => t.Id);

		}
        
        public override void Down()
        {
            DropTable("dbo.TestRuns");
        }
    }
}
