using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TMSCalculator
{
    internal class Program
    {//Калькулятор
        static void Main(string[] args)
        {

            while (true)
            {
            Flag:
                Console.WriteLine("Введите первое значение:");
                var valid1 = decimal.TryParse(Console.ReadLine(), out var value1);
                if (!valid1 && value1 >= 0)
                {
                    Console.WriteLine("Значение не валидное или меньше нуля, введите валидное значение!");
                    goto Flag;
                }
            Flag2:
                Console.WriteLine("Введите второе значение:");
                var valid2 = decimal.TryParse(Console.ReadLine(), out var value2);
                if (!valid2 && value2 >= 0)
                {
                    Console.WriteLine("Значение не валидное или меньше нуля, введите валидное значение!");
                    goto Flag2;
                }
                Console.WriteLine("Выберите операцию над значениямм, (+) (-) (*) (/) (%) (sqrt)");
                var chose = Console.ReadLine();
                Object res = chose switch
                {
                    "+" => value1 + value2,
                    "-" => value1 - value2,
                    "*" => value1 * value2,
                    "/" => value1 / value2,
                    "%" => value1 % value2,
                    "sqrt" => (Math.Sqrt((double)value1), Math.Sqrt((double)value2)),
                    _ => throw new Exception($"Операции {chose} не существует!")

                };
                if (res is (double sqrtValue1, double sqrtValue2))
                {
                    Console.WriteLine($"Корень из {value1} = {sqrtValue1}");
                    Console.WriteLine($"Корень из {value2} = {sqrtValue2}");
                }
                else
                {
                    Console.WriteLine($"{value1} {chose} {value2} = {res}");
                }

                Console.WriteLine("\nПродолжить ввод значений? Да - 1, Стоп - 0");
                string chose1 = Console.ReadLine();
                if (chose1 == "0")
                {
                    break;
                }
            }
        }
    }
}
