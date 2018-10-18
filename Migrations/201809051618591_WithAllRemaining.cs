namespace Clarksons.Cloud.Logging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WithAllRemaining : DbMigration
    {
        public override void Up()
        {
			CreateTable(
				"dbo.Results",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					ResultType = c.String(),
				})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.TestScenarios",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					Title = c.String(),
					TestRunId = c.Int(),
					ResultId = c.Int(),
					ExecutionTimingId = c.Int(nullable: false),
					TestStepFailurePointId = c.Int(),
					Tags = c.String(),
					FailureReason = c.String(),
					Error = c.String(),
					Feature = c.String(),
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.ExecutionTimings", t => t.ExecutionTimingId, cascadeDelete: true)
				.ForeignKey("dbo.Results", t => t.ResultId)
				.ForeignKey("dbo.TestRuns", t => t.TestRunId)
				.Index(t => t.TestRunId)
				.Index(t => t.ResultId)
				.Index(t => t.ExecutionTimingId);

			CreateTable(
				"dbo.TestSteps",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					StepDefinitionMethodName = c.String(),
					ResultId = c.Int(nullable: false),
					ExecutionTimingId = c.Int(nullable: false),
					TestScenarioId = c.Int(),
					StepRegex = c.String(),
					StepText = c.String(),
					StepDefinitionClass = c.String(),
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.ExecutionTimings", t => t.ExecutionTimingId, cascadeDelete: true)
				.ForeignKey("dbo.Results", t => t.ResultId, cascadeDelete: true)
				.ForeignKey("dbo.TestScenarios", t => t.TestScenarioId)
				.Index(t => t.ResultId)
				.Index(t => t.ExecutionTimingId)
				.Index(t => t.TestScenarioId);

		}

		public override void Down()
        {
            DropForeignKey("dbo.TestSteps", "TestScenarioId", "dbo.TestScenarios");
            DropForeignKey("dbo.TestSteps", "ResultId", "dbo.Results");
            DropForeignKey("dbo.TestSteps", "ExecutionTimingId", "dbo.ExecutionTimings");
            DropForeignKey("dbo.TestScenarios", "TestRunId", "dbo.TestRuns");
            DropForeignKey("dbo.TestScenarios", "ResultId", "dbo.Results");
            DropForeignKey("dbo.TestScenarios", "ExecutionTimingId", "dbo.ExecutionTimings");
            DropIndex("dbo.TestSteps", new[] { "TestScenarioId" });
            DropIndex("dbo.TestSteps", new[] { "ExecutionTimingId" });
            DropIndex("dbo.TestSteps", new[] { "ResultId" });
            DropIndex("dbo.TestScenarios", new[] { "ExecutionTimingId" });
            DropIndex("dbo.TestScenarios", new[] { "ResultId" });
            DropIndex("dbo.TestScenarios", new[] { "TestRunId" });
            DropTable("dbo.TestSteps");
            DropTable("dbo.TestScenarios");
            DropTable("dbo.Results");
        }
    }
}
