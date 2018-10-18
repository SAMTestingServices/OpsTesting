using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clarksons.Cloud.Logging.Models;

namespace Clarksons.Cloud.Logging
{
    public class LoggingContext:DbContext
    {
        public LoggingContext() : base("name=OpsCloudTestsLogging")
        {
           System.Data.Entity.Database.SetInitializer<LoggingContext>(new CreateDatabaseIfNotExists<LoggingContext>());
       }

        public DbSet<TestRun> TestRuns { get; set; }
        public DbSet<TestScenario> TestScenarios{ get; set; }
        public DbSet<TestStep> TestSteps{ get; set; }
        public DbSet<Result> Results{ get; set; }
        public DbSet<ExecutionTiming> ExecutionTiming{ get; set; }
    }
    }

