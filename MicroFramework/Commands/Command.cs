using MicroFramework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFramework
{
    /// <summary>
    /// Abstract class for command.
    /// </summary>
    abstract class Command
    {
        protected PageTester pageTester = PageTester.Get;
        protected Command NextCommand
        { get; set; }
        public abstract void Execute(Test command);
    }
}
