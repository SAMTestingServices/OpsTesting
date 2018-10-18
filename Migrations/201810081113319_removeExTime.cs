namespace Clarksons.Cloud.Logging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeExTime : DbMigration
    {
        public override void Up()
        {
			DropColumn("dbo.ExecutionTimings", "ExecutionTimeInSeconds");
		}
        
        public override void Down()
        {
            AddColumn("dbo.ExecutionTimings", "ExecutionTimeInSeconds", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
