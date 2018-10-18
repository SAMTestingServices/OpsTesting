namespace Clarksons.Cloud.Logging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedExecutionTime : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.ExecutionTimings", "ExecutionTime", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExecutionTimings", "ExecutionTime");
        }
    }
}
