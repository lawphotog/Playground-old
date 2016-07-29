using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new object[2, 20];
            var scoreInfo = new object[3, 21];

            for (int i = 0; i < 2; i++)
            {
                for (int y = 0; y < 20; y++)
                {
                    result[i, y] = 1;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    var temp = result[i, j];

                    scoreInfo[i + 1, j + 1] = temp;
                }
            }






            object[,] array2D = new object[,] { { "john", "emma" }, { "pual", "smith" }, { "joe", "chris" }, { "lauren", "lala" } };

            var decisionMatrix = new Object[33, 3];

            var array = Enumerable.Range(0, 10)
                      .Select(x => 0)
                      .ToArray();

            var sinBinInfo = new Object[21, 6];

            for (int i = 0; i < 21; i++)
            {
                for (int y = 0; y < 6; y++)
                {
                    sinBinInfo[i, y] = 0;
                }
            }


            Console.WriteLine(decisionMatrix[2,2]);

            Console.WriteLine(decisionMatrix[32, 2]);

            //var asdf = array2D[2, 1];

            //List<int[]> list = new List<int[]>
            //{
            //    new[] { 1, 2,3,4,5,6 }

            //};

            //int[,] array = CreateRectangularArray(list);
            //foreach (int x in array)
            //{
            //    Console.WriteLine(x); // 1, 2, 3, 4, 5, 6
            //}
            //Console.WriteLine(array[1, 1]); // 6

            ArrayList list = new ArrayList() { new[] { 1, 2 },new [] { 3, 4} };

            consume(array2D);

            Console.ReadLine();
        }

        static void consume(object a)
        {
            object[,] b = (object[,])a;
            Console.WriteLine(b[1,1]);
        }

        //static T[,] CreateRectangularArray<T>(IList<T[]> arrays)
        //{
        //    // TODO: Validation and special-casing for arrays.Count == 0
        //    int minorLength = arrays[0].Length;
        //    T[,] ret = new T[arrays.Count, minorLength];
        //    for (int i = 0; i < arrays.Count; i++)
        //    {
        //        var array = arrays[i];
        //        if (array.Length != minorLength)
        //        {
        //            throw new ArgumentException
        //                ("All arrays must be the same length");
        //        }
        //        for (int j = 0; j < minorLength; j++)
        //        {
        //            ret[i, j] = array[j];
        //        }
        //    }
        //    return ret;
        //}

    }
}
