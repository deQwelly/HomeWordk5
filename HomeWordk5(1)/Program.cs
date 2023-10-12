using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWordk5_1_
{
    internal class Program
    {
        /// <summary>
        /// Подсчитывает количество гласных и согласных букв в массиве
        /// </summary>
        /// <param name="consanants"></param>
        /// <param name="vowes"></param>
        /// <param name="file"></param>
        static void CountConsanantsAndVowes(out int consanants, out int vowes, params char[] file)
        {
            char[] all_consanants = new char[]
            {
                'a', 'e', 'i', 'o', 'u', 'y', 'а', 'у', 'о', 'ы', 'э', 'я', 'ю' , 'ё', 'и', 'е'
            };
            consanants = 0;
            vowes = 0;
            foreach (char c in file)
            {
                if (char.IsLetter(c))
                {
                    if (all_consanants.Contains(char.ToLower(c)))
                    {
                        consanants++;
                    }
                    else
                    {
                        vowes++;
                    }
                }
            }
        }

        /// <summary>
        /// Подсчитывает количество гласных и согласных букв в списке
        /// </summary>
        /// <param name="consanants"></param>
        /// <param name="vowes"></param>
        /// <param name="file"></param>
        static void CountConsanantsAndVowes(out int consanants, out int vowes, List<char> file)
        {
            char[] all_consanants = new char[]
            {
                'a', 'e', 'i', 'o', 'u', 'y', 'а', 'у', 'о', 'ы', 'э', 'я', 'ю' , 'ё', 'и', 'е'
            };
            consanants = 0;
            vowes = 0;
            foreach (char c in file)
            {
                if (char.IsLetter(c))
                {
                    if (all_consanants.Contains(char.ToLower(c)))
                    {
                        consanants++;
                    }
                    else
                    {
                        vowes++;
                    }
                }
            }
        }


        /// <summary>
        /// Создает матрицу с помощью двумерного массива
        /// </summary>
        /// <param name="matrix"></param>
        static void SetMatrix(out int?[,] matrix)
        {
            Console.Write("Введите порядок матрицы: ");
            if (int.TryParse(Console.ReadLine(), out int matrix_order))
            {
                matrix = new int?[matrix_order, matrix_order];
                Console.WriteLine("Будем задавать значения матрицы");
                bool flag = true;
                for (int i = 0; i < matrix_order; i++)
                {
                    for (int j = 0; j < matrix_order; j++)
                    {
                        Console.Write($"Введдите значение для элемента {i + 1}-ой строки {j + 1}-го столбца: ");
                        if (int.TryParse(Console.ReadLine(), out int matrix_value))
                        {
                            matrix[i, j] = matrix_value;
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели нецелочисленное значение или не ввели значение вовсе");
                            flag = false;
                        }
                        if (!flag)
                        {
                            matrix = null;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        matrix = null;
                        break;
                    }
                }
            }
            else
            {
                matrix = null;
                Console.WriteLine("Вы ввели нецелочисленное значение или не ввели значение вовсе");
            }
        }

        /// <summary>
        /// Печатает матрицу
        /// </summary>
        /// <param name="matrix"></param>
        static void PrintMatrix(int?[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Считает среднюю температуру в каждом месяце
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns></returns>
        static double[] ComputeAVGTemp(int[,] temperature)
        {
            double[] avg_temps = new double[12];
            for (int i = 0; i < 12; i++)
            {
                double month_avg = 0;
                for (int j = 0; j < 30; j++)
                {
                    month_avg += temperature[i, j];
                }
                month_avg /= 30;
                avg_temps[i] = month_avg;
            }
            return avg_temps;
        }

        /// <summary>
        /// Считает среднюю температуру в каждом месяце. На вход словарь, на выход словарь
        /// </summary>
        /// <param name="dict_tempetature"></param>
        /// <returns></returns>
        static Dictionary<string, double> ComputeAVGTemp(Dictionary<string, int[]> dict_tempetature)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            foreach (string s in dict_tempetature.Keys)
            {
                result.Add(s, Math.Round(dict_tempetature[s].Average(), 2));
            }
            return result;
        }

        /// <summary>
        /// Создает массив выбранной величины, заполняя его рандомными целочисленными значениями
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        static int[] SetRandomArray(Random rnd, int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(-30, 30);
            }
            return array;
        }

        static void Main(string[] args)
        {
            //Упражнение 6.1
            Console.WriteLine("Упражнение 6.1: Написать программу, которая вычисляет число гласных и согласных букв в файле.");
            char[] file_values = (File.ReadAllText(@"..\..\Task_1.txt")).ToArray();
            CountConsanantsAndVowes(out int consantans, out int vowes, file_values);
            Console.WriteLine($"Количество гласных букв: {consantans}\nКоличество согласных букв: {vowes}");

            //Упражнение 6.2
            Console.WriteLine("\nУпражнение 6.2: Написать программу, реализующую умножению двух матриц, заданных в виде двумерного массива");
            SetMatrix(out int?[,] matrix1);
            if (matrix1 != null)
            {
                Console.WriteLine("Введенная матрица: ");
                PrintMatrix(matrix1);
                SetMatrix(out int?[,] matrix2);
                if (matrix2 != null)
                {
                    Console.WriteLine("Введенная матрица: ");
                    PrintMatrix(matrix2);
                    int?[,] prod_matrixs = new int?[matrix1.GetLength(0), matrix1.GetLength(1)];
                    if (matrix1.GetLength(0) == matrix2.GetLength(0))
                    {
                        for (int i = 0; i < matrix1.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix1.GetLength(1); j++)
                            {
                                for (int x = 0; x < matrix2.GetLength(1); x ++)
                                {
                                    prod_matrixs[i, j] += matrix1[i, x] * matrix1[x, j];
                                }
                            }
                        }
                        Console.WriteLine();
                        PrintMatrix(prod_matrixs);
                    }
                }                

            }

            //Упражнение 6.3
            Console.WriteLine("\nУпражнение 6.3: Написать программу, вычисляющую среднюю температуру за год.");
            Random rnd = new Random();
            int[,] temperature = new int[12, 30];
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    temperature[i, j] = rnd.Next(-30, 30);
                }
            }
            string sort_temperatures = "";
            double[] avg_temperatures = ComputeAVGTemp(temperature);
            Array.Sort(avg_temperatures);
            foreach (int i in avg_temperatures)
            {
                sort_temperatures += i.ToString() + " ";
            }
            Console.WriteLine(sort_temperatures);

            //Домашнее задание 6.1
            Console.WriteLine("\nДомашнее задание 6.1: Упражнение 6.1 выполнить с помощью коллекции List<T>.");
            List<char> file = File.ReadAllText(@"..\..\Task_1.txt").ToList();
            CountConsanantsAndVowes(out int consanants1, out int vowes1, file);
            Console.WriteLine($"Количество гласных букв в файле: {consanants1} \nКоличество согласных букв в файле: {vowes1}");

            //Домашнее задание 6.2
            Console.WriteLine("\nДомашнее задание 6.2: Упражнение 6.2 выполнить с помощью коллекций LinkedList<LinkedList<T>>.");

            //Домашнее задание 6.3
            Console.WriteLine("\nДомашнее задание 6.3: Написать программу для упражнения 6.3, использовав класс Dictionary<TKey, TValue>.");
            Dictionary<string, int[]> dict_temperature = new Dictionary<string, int[]>()
            {
                ["январь"] = SetRandomArray(rnd, 30),
                ["февраль"] = SetRandomArray(rnd, 30),
                ["мрт"] = SetRandomArray(rnd, 30),
                ["апрель"] = SetRandomArray(rnd, 30),
                ["май"] = SetRandomArray(rnd, 30),
                ["июнь"] = SetRandomArray(rnd, 30),
                ["июль"] = SetRandomArray(rnd, 30),
                ["август"] = SetRandomArray(rnd, 30),
                ["сентябрь"] = SetRandomArray(rnd, 30),
                ["октябрь"] = SetRandomArray(rnd, 30),
                ["ноябрь"] = SetRandomArray(rnd, 30),
                ["декабрь"] = SetRandomArray(rnd, 30),
            };
            Dictionary<string, double> dict_avg_temperature = ComputeAVGTemp(dict_temperature);
            foreach (string s in dict_avg_temperature.Keys)
            {
                Console.WriteLine($"{s}: {dict_avg_temperature[s]}");
            }

            double[] temp = dict_avg_temperature.Values.ToArray();
            Array.Sort(temp);
            string sorted = "";
            for (int i = 0; i < (dict_avg_temperature.Values).Count; i++)
            {
                sorted += temp[i] + " ";
            }
            Console.WriteLine($"Отсортированные значения: {sorted}");
        }
    }
}
