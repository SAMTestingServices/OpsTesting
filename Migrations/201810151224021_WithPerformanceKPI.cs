namespace Clarksons.Cloud.Logging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WithPerformanceKPI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestSteps", "PerformanceKPI", c => c.Boolean(nullable: false));
            AddColumn("dbo.TestSteps", "SleepTimeForPerformanceKPIs", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestSteps", "SleepTimeForPerformanceKPIs");
            DropColumn("dbo.TestSteps", "PerformanceKPI");
        }
    }
}
