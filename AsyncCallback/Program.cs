using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCallback
{
    class Program
    {
        static byte[] buffer = new byte[100];

        static void Main(string[] args)
        {
            TestCallbackAPM();
            int i = 0;

            while (i <= 10000)
            {
                Console.WriteLine(i);
                i += 1;
            }

            Console.ReadLine();
        }

        static void TestCallbackAPM()
        {
            string filename = System.IO.Path.Combine(System.Environment.CurrentDirectory, "ConnectArchitecture.pdf");

            FileStream strm = new FileStream(filename,
                FileMode.Open, FileAccess.Read, FileShare.Read, 1024,
                FileOptions.Asynchronous);

            // Make the asynchronous call
            IAsyncResult result = strm.BeginRead(buffer, 0, buffer.Length,
                new System.AsyncCallback(CompleteRead), strm);
        }

        static void CompleteRead(IAsyncResult result)
        {
            Console.WriteLine("Read Completed");

            FileStream strm = (FileStream)result.AsyncState;

            // Finished, so we can call EndRead and it will return without blocking
            int numBytes = strm.EndRead(result);

            // Don't forget to close the stream
            strm.Close();

            Console.WriteLine("Read {0} Bytes", numBytes);
            Console.WriteLine(BitConverter.ToString(buffer));
        }
    }
}
