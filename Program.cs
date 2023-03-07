int TakeConsoleInt(string str = "")
{
    int _num;
    Console.Write(str);
    int.TryParse(Console.ReadLine()!, out _num);
    return _num;
}

double TakeConsoleDouble(string str = "")
{
    double _num;
    Console.Write(str);
    double.TryParse(Console.ReadLine()!, out _num);
    return _num;
}

void PrintArray2d(Array arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr.GetValue(i, j)}  ");
        }
        Console.WriteLine();
    }
}

double[,] FillArray2dDouble(int m0 = 1, int n1 = 1, double min = 1, double max = 1, int k = 2)
{
    int dec = (int)Math.Pow(10, k);
    double[,] arr = new double[m0, n1];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = new Random().Next((int)min * dec, (int)(max + 1) * dec) / (double)dec;
        }
    }
    return arr;
}

int[,] FillArray2dInt(int m0 = 3, int n1 = 4, int min = 0, int max = 10)
{
    int[,] arr = new int[m0, n1];
    for (int i = 0; i < m0; i++)
    {
        for (int j = 0; j < n1; j++)
        {
            arr[i, j] = new Random().Next(min, (max + 1));
        }
    }
    return arr;
}

void FindElement2d(double[,] arr, double element)
{
    bool exist = false;
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
            if (arr[i, j] == element)
                exist = true;
    if (exist == false)
        Console.Write($"{element} -> Такого элемента не существует");
    else
        for (int i = 0; i < arr.GetLength(0); i++)
            for (int j = 0; j < arr.GetLength(1); j++)
                if (arr[i, j] == element)
                    Console.Write($"Элемент находится в строке {i + 1}, столбце {j + 1}\n");
}

void AverageColumn(int[,] arr)
{
    double[] averagecolumn = new double[arr.GetLength(1)];
    double tempsum = 0;
    for (int i = 0; i < arr.GetLength(1); i++)
    {
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            tempsum += arr[j, i];
        }
        averagecolumn[i] = Math.Round((tempsum / arr.GetLength(0)), 2);
        tempsum = 0;
    }
    Console.Write($"{String.Join("; ", averagecolumn)}");
}

switch (TakeConsoleInt("Введите номер задачи(47, 50, 52): "))
{
    default:
        Console.Write("Введён некорректный номер задачи");
        break;
    case 47:
        Console.Write("Задайте двумерный массив размером m*n, заполненный случайными вещественными числами.\nm = 3, n = 4.\n0,5 7 -2 -0,2\n1 -3,3 8 -9,9\n8 7,8 -7,1 9\n");
        double[,] arr47 = FillArray2dDouble(TakeConsoleInt("Введите количество строк(m): "),
            TakeConsoleInt("Введите количество столбцов(n): "),
            TakeConsoleDouble("Введите минимальное значение массива: "),
            TakeConsoleDouble("Введите максимальное значениемассива: "),
            TakeConsoleInt("Введите количество знаков после запятой: "));
        PrintArray2d(arr47);
        break;
    case 50:
        Console.Write("Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает\nзначение этого элемента или же указание, что такого элемента нет. Например, задан массив:\n1 4 7 2\n5 9 2 3\n8 4 2 4\n17 -> такого числа в массиве нет\n");
        double[,] arr50 = FillArray2dDouble(TakeConsoleInt("Введите количество строк: "),
            TakeConsoleInt("Введите количество столбцов: "),
            TakeConsoleInt("Введите минимальное значение массива: "),
            TakeConsoleInt("Введите максимальное значениемассива: "),
            TakeConsoleInt("Введите количество знаков после запятой: "));
        PrintArray2d(arr50);
        FindElement2d(arr50, TakeConsoleDouble("Введите элемент, который нужно найти: "));
        break;
    case 52:
        Console.Write("Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.\nНапример, задан массив:\n1 4 7 2\n5 9 2 3\n8 4 2 4\nСреднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.\n");
        int[,] arr52 = FillArray2dInt(TakeConsoleInt("Введите количество строк(m): "),
            TakeConsoleInt("Введите количество столбцов(n): "),
            TakeConsoleInt("Введите минимальное значение массива: "),
            TakeConsoleInt("Введите максимальное значениемассива: "));
        PrintArray2d(arr52);
        AverageColumn(arr52);
        break;
}