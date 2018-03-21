using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFramework.Commands
{
    /// <summary>
    /// Class for command check link by href.
    /// </summary>
    class CommandCheckLinkPresentByHref : Command
    {
        public CommandCheckLinkPresentByHref(Command nextCommand)
        {
            NextCommand = nextCommand;
        }
        public override void Execute(Test test)
        {
            if (test.Command.StartsWith(Resource.checkLinkPresentByHref))
            {
                if (test.FirstParam != null)
                {
                    pageTester.CheckLinkPresentByHref(test);
                }
            }
            else if (NextCommand != null)
            {
                NextCommand.Execute(test);
            }
        }
    }
}
