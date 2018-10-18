namespace Clarksons.Cloud.Logging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedResults : DbMigration
    {
        public override void Up()
        {
			Sql("Insert into Results (ResultType) values ('Pass'),('Fail'),('Not implemented')");
		}
        
        public override void Down()
        {
            Sql("Delete from Results where ResultType In ('Pass','Fail','Not implemented')");
        }
    }
}

