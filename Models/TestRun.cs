using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Clarksons.Cloud.Logging.Models
{
    public class TestRun
    {
        private TestRun()
        {
            Console.WriteLine("In Tr constructor 1");
            //TestScenarios = new Collection<TestScenario>();
        }
        public TestRun(string module,string version,string environment)
        {
            Console.WriteLine("In Tr constructor 2");
            Console.WriteLine($"Version = {version}");
            ExecutionTiming = new ExecutionTiming {StartTime = DateTime.Now};
            TestScenarios = new Collection<TestScenario>();
            ApplicationVersion = version;
            Module = module;
            Environment = environment;
            Console.WriteLine("After Tr constructor 2");

        }
        public int Id { get; set; }

        public ExecutionTiming ExecutionTiming { get; set; }
        public int ExecutionTimingId { get; set; }

        public ICollection<TestScenario> TestScenarios { get; set; }

        public string ApplicationVersion { get; set; }

        public string Module { get; set; }

        public string Environment { get; set; }

    }
}
