using System;
using TechTalk.SpecFlow;

namespace Clarksons.Cloud.Logging.Models
{
    public class TestStep
    {
        private TestStep()
        {

        }

        public TestStep(StepInfo stepInfo, TestScenario _currentTestScenario, bool performanceKPI = false, int sleepTimeForPerformanceKPIs = 0)
        {
            ExecutionTiming = new ExecutionTiming { StartTime = DateTime.Now };
            StepText = stepInfo.Text;
            StepRegex = stepInfo.BindingMatch.StepBinding.Regex.ToString();
            StepDefinitionClass = stepInfo.BindingMatch.StepBinding.Method.Type.ToString();
            StepDefinitionMethodName = stepInfo.BindingMatch.StepBinding.Method.Name;
            TestScenario = _currentTestScenario;
            ResultId = 1;
			PerformanceKPI = performanceKPI;
			SleepTimeForPerformanceKPIs = sleepTimeForPerformanceKPIs;
		}

        public int Id { get; set; }
        public string StepDefinitionMethodName { get; set; }



        public Result Result { get; set; }
        public int ResultId { get; set; }

        public ExecutionTiming ExecutionTiming { get; set; }
        public int ExecutionTimingId { get; set; }

        public TestScenario TestScenario { get; set; }
        public int? TestScenarioId { get; set; }

        public string StepRegex { get; set; }
        public string StepText { get; set; }
		public string StepDefinitionClass { get; set; }

		public bool PerformanceKPI { get; set; }

		public int SleepTimeForPerformanceKPIs { get; set; }
	}
}
