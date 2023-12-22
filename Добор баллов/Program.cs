using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Добор_баллов
{
    internal class Program
    {
        /// <summary>
        /// метод для задания 1. ромбики
        /// </summary>
        static string CreateDiamond(int size)
        {
            if (size <= 0 || size % 2 == 0)
            {
                return null;
            }

            string result = "";
 
            for (int i = 1; i <= size; i += 2) //верхушка
            {
                string line = new string(' ', (size - i) / 2) + new string('*', i) + "\n";
                result += line;
            }

            for (int i = size - 2; i > 0; i -= 2)//низ
            {
                string line = new string(' ', (size - i) / 2) + new string('*', i) + "\n";
                result += line;
            }
           
            return result;
        }
        /// <summary>
        /// метод для задания 2. сортировка по длине
        /// </summary>
        static string[] SortByLength(string[] inputArray)
        {
            int length = inputArray.Length;

            for (int i = 0; i < length - 1; i++) 
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (inputArray[j].Length > inputArray[j + 1].Length)
                    {
                        string temp = inputArray[j];
                        inputArray[j] = inputArray[j + 1];
                        inputArray[j + 1] = temp;
                    }
                }
            }

            return inputArray;
        }
        /// <summary>
        /// методы для задания 4. смайлики
        /// </summary>
        static int CountSmileys(string[] arr)
        {
            return arr.Count(s => IsSmiley(s));
        }
        static bool IsSmiley(string smiley)
        {
            return smiley.Length == 2 || (smiley.Length == 3 && (smiley[1] == '-' || smiley[1] == '~')) &&
                   (smiley[0] == ':' || smiley[0] == ';') &&
                   (smiley[smiley.Length - 1] == ')' || smiley[smiley.Length - 1] == 'D');
        }
        /// <summary>
        /// метод для задания 5. ближайшее к нулю
        /// </summary>
        static int? ClosestToZero(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return null;
            }

            int closestToZero = numbers[0];

            foreach (int number in numbers)
            {
                if (Math.Abs(number) < Math.Abs(closestToZero) || (Math.Abs(number) == Math.Abs(closestToZero) && number > 0))
                {
                    closestToZero = number;
                }
            }
            return closestToZero;
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Задание 1. Ромбики.");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Введите размер.");
   
            int size = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Blue;
            string diamond = CreateDiamond(size);

            if (diamond != null)
            {
                Console.WriteLine(diamond);
            }
            else
            {
                Console.WriteLine("Размер ромбика не может быть четным или отрицательным.");
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Задание 2.");
            Console.ForegroundColor = ConsoleColor.White;

            string[] inputArray = { "Telescopes", "Glasses", "Eyes", "Monocles" };
            string[] sortedArray = SortByLength(inputArray);

            Console.WriteLine("Отсортированный массив: [" + string.Join(", ", sortedArray) + "]\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Задание 4. Рожицы");
            Console.ForegroundColor = ConsoleColor.White;

            string[] testArray = { ":)", ";D", ":~)", ";~D", ":)", ":D", ":-)", ";-D", ":~)", ";~D" };

            int count = CountSmileys(testArray);

            Console.WriteLine("Число смайликов: " + count);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗадание 5.");
            Console.ForegroundColor = ConsoleColor.White;

            int[] example1 = { 2, 4, -1, -3 };
            int? result1 = ClosestToZero(example1);
            Console.WriteLine("Ближайшее к нулю на отрезке [2, 4, -1, -3]: " + result1);

            int[] example2 = { 5, 2, -2 };
            int? result2 = ClosestToZero(example2);
            Console.WriteLine("Ближайшее к нулю на отрезке [5, 2, -2]: " + (result2.HasValue ? result2.ToString() : "None"));

            int[] example3 = { 5, 2, 2 };
            int? result3 = ClosestToZero(example3);
            Console.WriteLine("Ближайшее к нулю на отрезке [5, 2, 2]: " + result3);

            int[] example4 = { 13, 0, -6 };
            int? result4 = ClosestToZero(example4);
            Console.WriteLine("Ближайшее к нулю на отрезке [13, 0, -6]: " + result4);



        }
    }
}
