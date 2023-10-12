using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Временный
{
    internal class Program
    {
        static void PrintMatrix(int?[,] matrix)
        {
            Console.WriteLine("Заданная матрица: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static string ShowArray(params object[] any_array)
        {
            for (int i = 0; i < any_array.Length; i++)
            {
                any_array[i] = any_array[i].ToString();
            }
            return string.Join(" ", any_array);
        }
        static void Main(string[] args)
        {
            string[] strs = new string[] { "qwe", "rty", "uio", "pas" };
            string str = String.Join("", strs);
            Console.WriteLine(str);

            object[] objects = new object[] { "Петя", 1, true, false };
            Console.WriteLine($"{objects}\n{ShowArray(objects)}");
            
            ArrayList some_list = new ArrayList();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++) 
            {
                if (i % 2 == 0)
                {
                    some_list.Add((rnd.Next()).ToString());
                }
                else
                {
                    some_list.Add(rnd.Next());
                }
            }
            for (int i = 0; i < some_list.Count; i++)
            {
                Console.WriteLine($"{some_list[i]} {some_list[i].GetType()}");
            }
            Console.WriteLine("\n\n\n");
            int[,] myArr = new int[4, 5];
            Random ran = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    myArr[i, j] = ran.Next(1, 15);
                    Console.Write("{0}\t", myArr[i, j]);
                }
                Console.WriteLine();
            }
            int?[,] matrix1 = new int?[2, 3];
            int[,] matrix2 = new int[3, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix1[i, j] = rnd.Next(1, 5);
                }
            }
            int?[,] new_matrix1 = new int?[3, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    new_matrix1[3 - 1 - j, i] = matrix1[i, j];
                }
            }
            PrintMatrix(matrix1);
            PrintMatrix(new_matrix1);

            Console.WriteLine("\n\n\n");

            int[] newint = new int[3] { 3, 2, 1 };
            Array.Sort(newint);
            foreach (int i in newint) { Console.WriteLine(i); }
        }
    }
}
