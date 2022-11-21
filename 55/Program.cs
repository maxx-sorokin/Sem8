// Задача 55: Задайте двумерный массив. Напишите программу,
// которая заменяет строки и столбцы. В случае, если это невозможно,
// программа должна вывести сообщение для пользователя

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

/*if (array.GetLength(0) != array.GetLength(1))
{
    Console.WriteLine("Ошибка! Операция невозможна!");
    return;
}
else
{
    int[,] swapArray = SwapRowsAndColumns(array);
    Print2DArray(swapArray);
}*/
int[,] swapArray = SwapRowsAndColumns(array);
Print2DArray(swapArray);

int[,] SwapRowsAndColumns(int[,] array)
{
    int[,] newArray = new int[array.GetLength(1), array.GetLength(0)];

    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            newArray[i, j] = array[j, i];
        }
    }
    return newArray;
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