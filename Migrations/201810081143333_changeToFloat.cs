namespace Clarksons.Cloud.Logging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeToFloat : DbMigration
    {
        public override void Up()
        {
			AlterColumn("dbo.ExecutionTimings", "ExecutionTime", c => c.Single());
		}
        
        public override void Down()
        {
            AlterColumn("dbo.ExecutionTimings", "ExecutionTime", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
