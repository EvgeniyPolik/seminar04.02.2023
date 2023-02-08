int GetIntFromConsole(string message)
{
    Console.WriteLine(message);
    return int.Parse(Console.ReadLine() ?? "");
}

int[,] GetIntRandomArray(int arrayDimension, int startRange = 0, int endRange  = 100)  // Формирование массива
{
    var rnd = new  Random();
    int[,] result =  new int[arrayDimension, arrayDimension];
    for (var i = 0; i < arrayDimension; i++)
        for (var j = 0; j < arrayDimension; j++)
            result[i, j] = rnd.Next(startRange, endRange);
    return result;
}

void PrintArray(int[,] expArray, string message)  // Печать массива
{
    Console.WriteLine(message);
    int lenghtColumn = expArray.GetLength(0);
    int lenghtLine = expArray.GetLength(1);
    for (int i = 0; i < lenghtLine; i++)
    {
        for (int j = 0; j < lenghtColumn; j++)
        {
            Console.Write(expArray[i, j]);
            if (j < lenghtColumn - 1)
                Console.Write("\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void QuickSortLine(int[,] expArray, int lineNumber, int startIndex, int endIndex)  // Сортировка линии
{
    if (startIndex == endIndex)
        return;
    var pivotIndex = endIndex;
    var currentIndex = startIndex;
    for (int i = startIndex; i < endIndex; i++)
        if (expArray[lineNumber, i] <= expArray[lineNumber, pivotIndex] && i != pivotIndex)
        {
            expArray.ReplaceItems(lineNumber, currentIndex, i);
            currentIndex++;
        }
    expArray.ReplaceItems(lineNumber, currentIndex, pivotIndex);
    if (currentIndex > startIndex)
        QuickSortLine(expArray, lineNumber, startIndex, currentIndex - 1);
    if (currentIndex < endIndex)
        QuickSortLine(expArray, lineNumber, currentIndex + 1, endIndex);
}

void QuickSort(int[,] expArray)  // Перебор линий
{
    int arrayDimension = expArray.GetLength(1);
    for (int i = 0; i < arrayDimension; i++)
    {
        QuickSortLine(expArray, i, 0, arrayDimension - 1);
    }
}

var arrayDimension = GetIntFromConsole("Введите размерность массива: ");
int[,] expArray = GetIntRandomArray(arrayDimension);
PrintArray(expArray, "Исходный массив: ");
QuickSort(expArray);
PrintArray(expArray, "Отсортированный массив: ");


public static class ArrayExtensions  // Класс расширения с методом обмена элементов массива
{
    public static void ReplaceItems(this int[,] array, int lineNumber, int firstIndex, int secondIndex)
    {
        (array[lineNumber, firstIndex], array[lineNumber, secondIndex]) = (array[lineNumber, secondIndex], array[lineNumber, firstIndex]);
    }
}



