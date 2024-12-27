using System;

namespace MatrixOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[,] matrix = null;
            int rows = 0, cols = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Матрица: ");
                if (matrix != null)
                {
                    PrintMatrix(matrix);
                }
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Ввести размер матрицы и элементы");
                Console.WriteLine("2. Найти количество положительных и отрицательных чисел");
                Console.WriteLine("3. Сортировка элементов матрицы построчно");
                Console.WriteLine("4. Инверсия элементов матрицы построчно");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите количество строк: ");
                        rows = int.Parse(Console.ReadLine());
                        Console.Write("Введите количество столбцов: ");
                        cols = int.Parse(Console.ReadLine());
                        matrix = new int[rows, cols];
                        Console.WriteLine("Введите элементы матрицы:");
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                Console.Write($"Элемент [{i},{j}]: ");
                                matrix[i, j] = int.Parse(Console.ReadLine());
                            }
                        }
                        break;

                    case "2":
                        if (matrix != null)
                        {
                            int positiveCount = 0, negativeCount = 0;
                            CountPositiveNegative(matrix, ref positiveCount, ref negativeCount);
                            Console.WriteLine($"Количество положительных чисел: {positiveCount}");
                            Console.WriteLine($"Количество отрицательных чисел: {negativeCount}");
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте матрицу!");
                        }
                        break;

                    case "3":
                        if (matrix != null)
                        {
                            Console.WriteLine("Сортировка по возрастанию построчно:");
                            SortMatrixRows(matrix, true);
                            PrintMatrix(matrix);

                            Console.WriteLine("Сортировка по убыванию построчно:");
                            SortMatrixRows(matrix, false);
                            PrintMatrix(matrix);
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте матрицу!");
                        }
                        break;

                    case "4":
                        if (matrix != null)
                        {
                            Console.WriteLine("Инверсия элементов матрицы построчно:");
                            InvertMatrixRows(matrix);
                            PrintMatrix(matrix);
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте матрицу!");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void CountPositiveNegative(int[,] matrix, ref int positiveCount, ref int negativeCount)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        positiveCount++;
                    else if (matrix[i, j] < 0)
                        negativeCount++;
                }
            }
        }

       
        static void SortMatrixRows(int[,] matrix, bool ascending)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    for (int k = j + 1; k < matrix.GetLength(1); k++)
                    {
                        if ((ascending && matrix[i, j] > matrix[i, k]) || (!ascending && matrix[i, j] < matrix[i, k]))
                        {
                            int temp = matrix[i, j];
                            matrix[i, j] = matrix[i, k];
                            matrix[i, k] = temp;
                        }
                    }
                }
            }
        }

        
        static void InvertMatrixRows(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int start = 0, end = matrix.GetLength(1) - 1;
                while (start < end)
                {
                    int temp = matrix[i, start];
                    matrix[i, start] = matrix[i, end];
                    matrix[i, end] = temp;
                    start++;
                    end--;
                }
            }
        }
    }
}
