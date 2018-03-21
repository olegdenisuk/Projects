using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFramework.Commands
{
    /// <summary>
    /// Class test.
    /// </summary>
    class Test
    {
        /// <summary>
        /// Success of the test.
        /// </summary>
        public bool IsSuccess
        { get; private set; }

        /// <summary>
        /// First string parameter of the test.
        /// </summary>
        public string FirstParam
        { get; private set; }

        /// <summary>
        /// Second int parameter of the test.
        /// </summary>
        public int SecondParam
        { get; private set; }
        
        /// <summary>
        /// String command.
        /// </summary>
        public string Command
        { get; private set; }

        /// <summary>
        /// Test execution time.
        /// </summary>
        public TimeSpan RunTime
        { get; private set; }

        /// <summary>
        /// Return result test execution in specified format.
        /// </summary>
        public string Result
        {
            get
            {
                char isSuccess = IsSuccess ? '+' : '!';
                string result = $"{isSuccess} [{Command}] {RunTime.ToString(@"s\.fff")}";
                return result;
            }
           
        }
        public Test(string command)
        {
            Command = command;
            string[] splittedCommand = command.Split(Resource.separators);
            if (splittedCommand.Length > 1)
            { FirstParam = splittedCommand[1]; }
            if (splittedCommand.Length > 3)
            { SecondParam = Int32.Parse(splittedCommand[3]); }
        }

        /// <summary>
        /// Set result of test.
        /// </summary>
        /// <param name="time">test execution time</param>
        /// <param name="isSuccess">true if test passed</param>
        public void SetResult(TimeSpan time, bool isSuccess)
        {
            RunTime = time;
            IsSuccess = isSuccess;
        }        
    }
}
