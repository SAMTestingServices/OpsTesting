namespace Clarksons.Cloud.Logging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoubleToDecimal : DbMigration
    {
        public override void Up()
        {
			AlterColumn("dbo.ExecutionTimings", "ExecutionTimeInSeconds", c => c.Decimal(precision: 18, scale: 2));
		}
        
        public override void Down()
        {
            AlterColumn("dbo.ExecutionTimings", "ExecutionTimeInSeconds", c => c.Int());
        }
    }
}
