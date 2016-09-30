using System;
using System.Collections.Generic;
using System.Reflection;


namespace Samples
{
    public class ReflectionDemo
    {
        public static void Run()
        {        
            Type t = typeof(Contact);
            var instance = new Contact("Dino", "Esposito");
            var name = t.InvokeMember("GetFullName", BindingFlags.InvokeMethod, null, instance, null);
            Console.WriteLine(name);
        }
    }
}
