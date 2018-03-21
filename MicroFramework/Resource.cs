using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFramework.Commands
{
    /// <summary>
    /// Class for resource.
    /// </summary>
    class Resource
    {
        static public string checkPageContains = "checkPageContains";
        static public string checkPageTitle = "checkPageTitle";
        static public string checkLinkPresentByName = "checkLinkPresentByName";
        static public string checkLinkPresentByHref = "checkLinkPresentByHref";
        static public string open = "open";
        static public char[] separators = { '"' };
        static public string inputFile = "InputTests.txt";
        static public string outputFile = "OutputTests.txt";
    }
}
