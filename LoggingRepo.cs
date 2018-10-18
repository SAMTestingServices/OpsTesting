using System;
using System.Collections.Generic;
using System.Linq;
using Clarksons.Cloud.Logging.Models;

namespace Clarksons.Cloud.Logging
{
    public class LoggingRepo
    {
        private readonly LoggingContext _dbContext;


        public LoggingRepo()
        {
            _dbContext = new LoggingContext();
        }

        

        public void SaveTestRunData(TestRun testrun)
        {
           
                if (testrun.Id != 0)
                {

                    var executionTimingInDb = _dbContext.ExecutionTiming
                        .FirstOrDefault(et => et.Id == testrun.ExecutionTiming.Id);

                    var testrunInDb = _dbContext.TestRuns
                        .FirstOrDefault(tr => tr.Id == testrun.Id);

				//executionTimingInDb = testrun.ExecutionTiming;
				//testrunIndb = testrun;

				//dbContext.Update(testrunIndb);

				_dbContext.Entry(executionTimingInDb).CurrentValues.SetValues(testrun.ExecutionTiming);
                    _dbContext.Entry(testrunInDb).CurrentValues.SetValues(testrun);
                    _dbContext.SaveChanges();
                    return;
                }

            _dbContext.TestRuns.Add(testrun);
			_dbContext.SaveChanges();
		}




        

        public void SaveScenarioData(TestScenario testscenario, TestRun testrun)
        {

           if (testscenario.Id != 0)
                {

                    Console.WriteLine("At start of initial Save Scenario data");
                    var testScenarioInDb = _dbContext.TestScenarios
                            // .Include(ts=>ts.TestStepFailurePoint)
                            .First(ts => ts.Id == testscenario.Id);

                    var testScenarioExecutionTimingInDb =
                        _dbContext.ExecutionTiming.First(et => et.Id == testscenario.ExecutionTimingId);


                    _dbContext.Entry(testScenarioInDb).CurrentValues.SetValues(testscenario);
                    _dbContext.Entry(testScenarioExecutionTimingInDb).CurrentValues
                        .SetValues(testscenario.ExecutionTiming);




                    _dbContext.TestSteps.AddRange(testscenario.TestSteps);



                    _dbContext.SaveChanges();


                    //To-Do: Prop don't need to do below if I improve TestScenario model
                    if (testscenario.ResultId == 2)
                    {
                        testScenarioInDb.TestStepFailurePointId =
                         testScenarioInDb.TestSteps.First(ts => ts.ResultId == 2).Id;
                        _dbContext.SaveChanges();
                    }

                    Console.WriteLine("At end of initial Save Scenario data");
                    return;



                }

			var testRuninDb2 = _dbContext.TestRuns.First(tr => tr.Id == testrun.Id);

			testRuninDb2.TestScenarios.Add(testscenario);

			_dbContext.SaveChanges();


		}




        

        public async void SaveStepData(IEnumerable<TestStep> teststeps)
        {
            
            foreach (var teststep in teststeps)
            {
                _dbContext.TestSteps.Add(teststep);
            }


            await _dbContext.SaveChangesAsync();
        }
        public async void SaveExecutionTimingData(ExecutionTiming executionTiming)
        {
 


            await _dbContext.SaveChangesAsync();
        }



    }
}
