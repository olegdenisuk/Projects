using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFramework.Commands
{
    /// <summary>
    /// Class for command open url.
    /// </summary>
    class CommandOpen : Command
    {
        public CommandOpen(Command nextCommand)
        {
            NextCommand = nextCommand;
        }
        public override void Execute(Test test)
        {
            if (test.Command.StartsWith(Resource.open))
            {
                if (test.FirstParam != null )
                {
                    pageTester.Open(test);
                }
            }

            else if (NextCommand != null)
            {
                NextCommand.Execute(test);
            }
        }


    }
}
