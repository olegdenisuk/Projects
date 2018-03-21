using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFramework.Commands
{
    /// <summary>
    /// Class for command check page contain.
    /// </summary>
    class CommandCheckPageContains : Command
    {
        public CommandCheckPageContains(Command nextCommand)
        {
            NextCommand = nextCommand;
        }
        public override void Execute(Test test)
        {
            if (test.Command.StartsWith(Resource.checkPageContains))
            {
                if (test.FirstParam != null)
                {
                    pageTester.CheckPageContains(test);
                }
            }

            else if (NextCommand != null)
            {
                NextCommand.Execute(test);
            }
        }
    }
}
