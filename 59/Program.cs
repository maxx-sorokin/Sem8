// Задача 59: Задайте двумерный массив из целых чисел.
// Напишите программу, которая удалит строку и столбец,
// на пересечении которых расположен наименьший элемент массива.

Console.WriteLine("Введите количество строк");
bool isParsedM = int.TryParse(Console.ReadLine(), out int m);
Console.WriteLine("Введите количество столбцов");
bool isParsedN = int.TryParse(Console.ReadLine(), out int n);

if (!isParsedM || !isParsedN)
{
    Console.WriteLine("Ошибка!");
    return;
}

int[,] array = CreateRandom2DArray(m, n);
Print2DArray(array);

Console.WriteLine();

(int, int) indexes = FindAddressOfMinNumber(array);

int[,] newArray = DeleteRowAndColumn(array, indexes.Item1, indexes.Item2);
Print2DArray(newArray);

int[,] DeleteRowAndColumn(int[,] array, int indexRow, int indexColumn)
{
    int[,] result = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
    int row = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int column = 0;
        if (i != indexRow)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (j != indexColumn)
                {
                    result[row, column] = array[i, j];
                    column++;
                }
            }
            row++;
        }
    }
    return result;
}

(int, int) FindAddressOfMinNumber(int[,] array)
{
    int indexRow = 0;
    int indexColumn = 0;
    int minNumber = array[0, 0];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < minNumber)
            {
                minNumber = array[i, j];
                indexRow = i;
                indexColumn = j;
            }
        }
    }
    return (indexRow, indexColumn);
}

int[,] CreateRandom2DArray(int m, int n)
{
    int[,] array = new int[m, n];

    Random random = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(1, 10);
        }
    }
    return array;
}

void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}