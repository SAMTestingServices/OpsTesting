using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clarksons.Cloud.Logging.Models
{
    public class TestScenario
    {

        public TestScenario()
        {
            //TestSteps = new Collection<TestStep>();
        }

        public TestScenario(string scenarioInfoTitle, string featureInfoTitle, TestRun testRun, string tags)
        {
            ExecutionTiming = new ExecutionTiming { StartTime = DateTime.Now };
            TestSteps = new Collection<TestStep>();
            Title = scenarioInfoTitle;
            Feature = featureInfoTitle;
            TestRun = testRun;
            Tags = tags;
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public TestRun TestRun { get; set; }
        public int? TestRunId { get; set; }

        public Result Result { get; set; }
        public int? ResultId { get; set; }

        public ExecutionTiming ExecutionTiming { get; set; }
        public int ExecutionTimingId { get; set; }

        [NotMapped]
        public TestStep TestStepFailurePoint { get; set; }
        public int? TestStepFailurePointId { get; set; }
        public ICollection<TestStep> TestSteps { get; set; }

        public string Tags { get; set; }

        public string FailureReason { get; set; }

        public string Error { get; set; }

        public string Feature { get; set; }

    }




}

