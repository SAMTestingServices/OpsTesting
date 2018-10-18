namespace Clarksons.Cloud.Logging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WithExecutionTiming : DbMigration
    {
        public override void Up()
        {
			CreateTable(
				"dbo.ExecutionTimings",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					StartTime = c.DateTime(nullable: false),
					FinishTime = c.DateTime(),
					ExecutionTimeInSeconds = c.Int(),
				})
				.PrimaryKey(t => t.Id);

			AddColumn("dbo.TestRuns", "ExecutionTimingId", c => c.Int(nullable: false));
			CreateIndex("dbo.TestRuns", "ExecutionTimingId");
			AddForeignKey("dbo.TestRuns", "ExecutionTimingId", "dbo.ExecutionTimings", "Id", cascadeDelete: true);
		}
        
        public override void Down()
        {
            DropForeignKey("dbo.TestRuns", "ExecutionTimingId", "dbo.ExecutionTimings");
            DropIndex("dbo.TestRuns", new[] { "ExecutionTimingId" });
            DropColumn("dbo.TestRuns", "ExecutionTimingId");
            DropTable("dbo.ExecutionTimings");
        }
    }
}
