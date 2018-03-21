using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFramework.Commands
{
    /// <summary>
    /// Class for command check page by title.
    /// </summary>
    class CommandCheckPageTitle : Command
    {
        public CommandCheckPageTitle(Command nextCommand)
        {
            NextCommand = nextCommand;
        }
        public override void Execute(Test test)
        {
            if (test.Command.StartsWith(Resource.checkPageTitle))
            {
                if (test.FirstParam != null)
                {
                    pageTester.CheckPageTitle(test);
                }
            }

            else if (NextCommand != null)
            {
                NextCommand.Execute(test);
            }
        }
    }
}
