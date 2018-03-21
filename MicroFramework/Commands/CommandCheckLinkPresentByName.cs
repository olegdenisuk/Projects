using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFramework.Commands
{
    /// <summary>
    /// Class for command check link by name.
    /// </summary>
    class CommandCheckLinkPresentByName : Command
    {
        public CommandCheckLinkPresentByName(Command nextCommand)
        {
            NextCommand = nextCommand;
        }
        public override void Execute(Test test)
        {
            if (test.Command.StartsWith(Resource.checkLinkPresentByName))
            {
                if (test.FirstParam != null)
                {
                    pageTester.CheckLinkPresentByName(test);
                }
            }

            else if (NextCommand != null)
            {
                NextCommand.Execute(test);
            }
        }
    }
}
