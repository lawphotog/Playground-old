using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new object[5];
            double[] b = new double[6];

            for (int j = 0; j < 6; j++)
            {
                b[j] = j;
            }

            for (int i = 0; i < 5; i++)
            {
                a[i] = b;
            }

            var c = new object[6, 5];

            c[0, 0] = ((double[])a[0])[0];
            c[0, 1] = ((double[])a[1])[0];
            c[0, 2] = ((double[])a[2])[0];
            c[0, 3] = ((double[])a[3])[0];
            c[0, 4] = ((double[])a[4])[0];
            c[1, 0] = ((double[])a[0])[1];
            c[1, 1] = ((double[])a[1])[1];
            c[1, 2] = ((double[])a[2])[1];
            c[1, 3] = ((double[])a[3])[1];
            c[1, 4] = ((double[])a[4])[1];
            c[2, 0] = ((double[])a[0])[2];
            c[2, 1] = ((double[])a[1])[2];
            c[2, 2] = ((double[])a[2])[2];
            c[2, 3] = ((double[])a[3])[2];
            c[2, 4] = ((double[])a[4])[2];
            c[3, 0] = ((double[])a[0])[3];
            c[3, 1] = ((double[])a[1])[3];
            c[3, 2] = ((double[])a[2])[3];
            c[3, 3] = ((double[])a[3])[3];
            c[3, 4] = ((double[])a[4])[3];
            c[4, 0] = ((double[])a[0])[4];
            c[4, 1] = ((double[])a[1])[4];
            c[4, 2] = ((double[])a[2])[4];
            c[4, 3] = ((double[])a[3])[4];
            c[4, 4] = ((double[])a[4])[4];
            c[5, 0] = ((double[])a[0])[5];
            c[5, 1] = ((double[])a[1])[5];
            c[5, 2] = ((double[])a[2])[5];
            c[5, 3] = ((double[])a[3])[5];
            c[5, 4] = ((double[])a[4])[5];

        }
    }
}
