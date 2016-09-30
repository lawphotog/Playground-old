using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCwithMEF.Controllers
{
    [InheritedExport]
    interface ILogger
    {
        void Log(string message);
    }

    public class TextFileLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine("TextFileLogger is logging .." + message);
        }
    }
}
