using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5_2_
{
    internal class Program
    {
        public struct Student
        {
            public string first_name;
            public string second_name;
            public DateTime birthday;
            public ArrayList exams;
            public ArrayList points;
        }
        static void Main(string[] args)
        {
            //Упражнение 2
            Console.WriteLine("Упражнение 2: Создать студента из вашей группы (фамилия, имя, год рождения," +
                " с каким экзаменом\r\nпоступил, баллы). Создать словарь для студентов из вашей группы" +
                " (10 человек).\r\nНеобходимо прочитать информацию о студентах с файла.");
            Console.WriteLine()
        }
    }
}
