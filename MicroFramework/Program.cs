using MicroFramework.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace MicroFramework
{
    /// <summary>
    /// Microframework
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point of program.
        /// </summary>
        static void Main()
        {            
            try
            {
                List<Test> listTests = new List<Test>();

                Command command = new CommandOpen(new CommandCheckLinkPresentByHref(
                   new CommandCheckLinkPresentByName(new CommandCheckPageTitle(new CommandCheckPageContains(null)))));

                using (StreamWriter streamWriter = new StreamWriter(Resource.outputFile))
                {
                    using (StreamReader streamReader = new StreamReader(Resource.inputFile))
                    {
                        string line = string.Empty;
                        while ((line = streamReader.ReadLine()) != null)
                        {                            
                            Test test = new Test(line);
                            listTests.Add(test);
                            command.Execute(test);
                            streamWriter.WriteLine(test.Result);                          
                        }
                    }

                    TimeSpan totalTime = TimeSpan.Zero;
                    int pasedTests = 0;
                    int failedTests = 0;
                    foreach (Test test in listTests)
                    {
                        totalTime += test.RunTime;
                        if (test.IsSuccess)
                        {
                            pasedTests++;
                        }
                        else
                        {
                            failedTests++;
                        }
                    }
                    TimeSpan averageTime = TimeSpan.FromTicks(totalTime.Ticks / (pasedTests + failedTests));
                    streamWriter.WriteLine($"Total tests: {pasedTests + failedTests}");
                    streamWriter.WriteLine($"Passed/Failed: {pasedTests}/{failedTests}");
                    streamWriter.WriteLine($"Total time: {totalTime.ToString(@"s\.fff")}");
                    streamWriter.WriteLine($"Average time: {averageTime.ToString(@"s\.fff")}");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File couldn't be read.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error.");
            }            
        }
    }
}