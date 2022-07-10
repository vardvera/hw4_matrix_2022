using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace hw_4_1
{
    class Program
    {
        static void Main(string[] args)
        {

            // ввод данных

            // создаем 4 вида операции:
            //умножение на коэффициент (нцжна матрица и коэффициент)
            //сложение матриц (нужно 2 матрицы axb и axb)
            //вычитание матриц(нужно 2 матрицы axb и axb)
            //перемножение матриц(нужно 2 матрицы axb и bxa)

            Random r = new Random();

            Console.WriteLine("Выберете операцию над матрицами: \nУмножение на коэффициент - 1, \nСложение - 2,  \nВычитание - 3, \nПеремножение матриц - 4;");
            int operation;
            int[] typeOfOperation = { 1, 2, 3, 4 };

            while (!int.TryParse(Console.ReadLine(), out operation) || typeOfOperation.Contains(operation) == false)
            {
                Console.WriteLine("Ошибка ввода.Введите число от 1 до 4 из списка:");
            }

            int N = 1; // N - число матриц, при умножении на коэффициент нужна 1 матрица

            // Ввводим коэффициент для умножения для 1 операции (умножение на коэффициент)
            int c = 0;
            if (operation == 1)
            {
                Console.WriteLine("Введите коэффициент:");
                while (!int.TryParse(Console.ReadLine(), out c))
                {
                    Console.WriteLine("Ошибка ввода.Введите целое число:");
                }

            }

            if (operation != 1)
            {
                Console.WriteLine("Введите количество матриц");
                while (!int.TryParse(Console.ReadLine(), out N))
                {
                    Console.WriteLine("Ошибка ввода.Введите целое число:");
                }
            }

            // вводим кол-во строк в матрице
            int row;

            if (operation == 4) { Console.WriteLine("Введите количество строк 1 матрицы:"); }         // в случае перемножении матриц кол-во столбцов m1  = кол-во строк m2
            else if (operation == 1) { Console.WriteLine("Введите количество строк матрицы:"); }
            else { Console.WriteLine("Введите количество строк матриц:"); }

            while (!int.TryParse(Console.ReadLine(), out row))
            {
                Console.WriteLine("Ошибка ввода.Введите целое число:");
            }


            // вводим кол-во столбцов матриц 
            int[] matrix_columns_number = new int[N];
            int columns = 0;

            for (int i = 0; i < N; i++)
            {
                if (operation == 4) { Console.WriteLine($"Введите количество столбцов {i + 1} матрицы:"); }
                else if (operation == 1) { Console.WriteLine($"Введите количество столбцов матрицы:"); }
                else { Console.WriteLine($"Введите количество столбцов матриц:"); }

                while (!int.TryParse(Console.ReadLine(), out columns))
                {
                    Console.WriteLine("Ошибка ввода.Введите целое число:");
                }
                if (operation != 4) { break; }
                matrix_columns_number[i] = columns;
            }

            Console.Clear();

            //создание и заполнение матриц
            int[][,] allMatrices = new int[N][,];                       // задаем все матрицы
            int[,] resultMatrix = new int[100, 100];                     // задаем матрицу с результатами для умножения на коэффициент
            int[][,] finalMatrix = new int[N - 1][,];                   // задаем матрицу с результатами сложения, вычитания и перемножения

            for (int n = 0; n < N; n++)
            {
                switch (operation)
                {
                    case 4:    // заполнение матриц правильного размера для перемножения между собой
                        if (n == 0)
                        {
                            allMatrices[n] = new int[row, matrix_columns_number[n]];
                            for (int i = 0; i < row; i++)
                            {
                                Console.Write('|');
                                for (int j = 0; j < matrix_columns_number[n]; j++)
                                {
                                    allMatrices[n][i, j] = r.Next(10);
                                    Console.Write($" { allMatrices[n][i, j],4} ");
                                }
                                Console.Write("|\n");
                            }
                            Console.WriteLine("\n  x\n ");

                        }
                        else
                        {
                            allMatrices[n] = new int[matrix_columns_number[n - 1], matrix_columns_number[n]];
                            for (int i = 0; i < matrix_columns_number[n - 1]; i++)
                            {
                                Console.Write("|");
                                for (int j = 0; j < matrix_columns_number[n]; j++)
                                {
                                    allMatrices[n][i, j] = r.Next(10);
                                    Console.Write($"{allMatrices[n][i, j],4}");
                                }
                                Console.WriteLine("|");
                            }
                            Console.WriteLine("\n");
                            if (n < N - 1) { Console.WriteLine("  x\n"); }

                        }
                        break;

                    default:
                        allMatrices[n] = new int[row, columns];
                        for (int i = 0; i < row; i++)
                        {
                            Console.Write("|");
                            for (int j = 0; j < columns; j++)
                            {
                                allMatrices[n][i, j] = r.Next(10);
                                Console.Write($"{allMatrices[n][i, j],4}");
                            }
                            Console.WriteLine("|");
                        }
                        if (n < N - 1)
                        {
                            switch (operation)
                            {
                                case 2:
                                    Console.WriteLine("\n+\n");
                                    break;

                                case 3:
                                    Console.WriteLine("\n-\n");
                                    break;
                            }
                        }
                        break;
                }
            }



            // результат операций над матрицами

            switch (operation)
            {
                case 1: // умножение на коэффициент
                    Console.WriteLine($"\n x   {c}   =\n");
                    for (int i = 0; i < row; i++)
                    {
                        Console.Write("|");
                        for (int j = 0; j < columns; j++)
                        {
                            resultMatrix[i, j] = allMatrices[0][i, j] * c;
                            Console.Write($"{resultMatrix[i, j],4}");
                        }
                        Console.Write("|\n");
                    }
                    break;

                case 4: // перемноженеие N числа матриц

                    Console.WriteLine("\n=\n");

                    for (int n = 1; n < N; n++)
                    {
                        finalMatrix[n - 1] = new int[row, matrix_columns_number[n]];
                        for (int i = 0; i < row; i++)
                        {
                            Console.Write("|");
                            for (int j = 0; j < matrix_columns_number[n]; j++)
                            {
                                for (int k = 0; k < matrix_columns_number[n - 1]; k++)
                                {
                                    if (n < 2) { finalMatrix[n - 1][i, j] += allMatrices[n - 1][i, k] * allMatrices[n][k, j]; }
                                    else { finalMatrix[n - 1][i, j] += finalMatrix[n - 2][i, k] * allMatrices[n][k, j]; }         // если число матриц больше 2, ответ на основе полученной промежуточной матрицы
                                }
                                Console.Write($"{finalMatrix[n - 1][i, j],6}");
                            }
                            Console.Write("|\n");
                        }
                        Console.Write("\n");
                    }
                    break;

                default: // сложение и вычитание матриц

                    Console.WriteLine("\n=\n");
                    for (int n = 1; n < N; n++)
                    {
                        finalMatrix[n - 1] = new int[row, columns];
                        for (int i = 0; i < row; i++)
                        {
                            Console.Write("|");
                            for (int j = 0; j < columns; j++)
                            {
                                if (operation == 2)
                                {
                                    if (n < 2) { finalMatrix[n - 1][i, j] = allMatrices[n - 1][i, j] + allMatrices[n][i, j]; }
                                    else { finalMatrix[n - 1][i, j] = finalMatrix[n - 2][i, j] + allMatrices[n][i, j]; }         // если число матриц больше 2, ответ на основе полученной промежуточной матрицы
                                }
                                else
                                {
                                    if (n < 2) { finalMatrix[n - 1][i, j] = allMatrices[n - 1][i, j] - allMatrices[n][i, j]; }
                                    else { finalMatrix[n - 1][i, j] = finalMatrix[n - 2][i, j] - allMatrices[n][i, j]; }
                                }
                                Console.Write($"{finalMatrix[n - 1][i, j],6}");
                            }

                            Console.Write("|\n");
                        }
                        Console.Write("\n");
                    }
                    break;

            }


        }
    }
}
