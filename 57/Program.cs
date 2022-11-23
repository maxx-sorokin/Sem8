// Задача 57: Составить частотный словарь элементов двумерного
// массива. Частотный словарь содержит информацию о том,
// сколько раз встречается элемент входных данных.

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

int[,] newArray = FrequencyDictionary(array);
Print2DArray(newArray);

int[,] FrequencyDictionary(int[,] array)
{
    int[,] result = new int[2, array.Length];
    int index = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int findIndex = Check(result, array[i, j]);
            if (findIndex != -1)
            {
                result[1, findIndex]++;
            }
            else
            {
                result[0, index] = array[i, j];
                result[1, index] = 1;
                index++;
            }
        }
    }
    return Trim(result);
}

int[,] Trim(int[,] array)
{
    int index = array.GetLength(1) - 1;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        if (array[1, i] == 0)
        {
            index = i;
            break;
        }
    }
    int[,] result = new int[2, index];
    for (int i = 0; i < result.GetLength(1); i++)
    {
        result[0, i] = array[0, i];
        result[1, i] = array[1, i];
    }
    return result;
}

int Check(int[,] array, int number)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        if (array[0, i] == number)
        {
            return i;
        }
    }
    return -1;
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