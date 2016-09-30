using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Reflection;
using System.Xml.Linq;

namespace Samples
{
    class Program
    {
        static void Main(String[] args)
        {
            // ReflectionDemo.Run();

            // ===

            // ClassicXmlParsingDemo.Run();

            // ===

            ExpandoXmlParsingDemo.Run();
            
            // ===

            Console.WriteLine("\n\n\nPress any key");
            Console.ReadKey();
        }
    }
}
