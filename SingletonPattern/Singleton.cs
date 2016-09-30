using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class Singleton
    {
        private static Singleton _instance;

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;   
            }
        }

        internal void DoStuff()
        {
            Console.WriteLine("Hello World");
        }
    }
}
