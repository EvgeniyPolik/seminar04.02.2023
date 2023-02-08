﻿int[,] GetIntRandomArray(int arrayDimension, int startRange = 0, int endRange  = 100)
{
    var rnd = new  Random();
    int[,] result =  new int[arrayDimension, arrayDimension];
    for (var i = 0; i < arrayDimension; i++)
        for (var j = 0; j < arrayDimension; j++)
            result[i, j] = rnd.Next(startRange, endRange);
    return result;
}

void PrintArray(int[,] expArray)
{
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
}

void MixLineInArray(int[,] expArray)
{
    int lenghtLine = expArray.GetLength(0);
    int lenghtColumn = expArray.GetLength(1);
    for (int i = 0; i < lenghtLine; i++)
        (expArray[0, i], expArray[lenghtColumn - 1, i]) = (expArray[lenghtColumn - 1, i], expArray[0, i]);
}

Console.WriteLine("Введите размерность массива: ");
var arrayDimension = int.Parse(Console.ReadLine() ?? "");
int[,] expArray = GetIntRandomArray(arrayDimension);
Console.WriteLine("Исходный массив: ");
PrintArray(expArray);
MixLineInArray(expArray);
Console.WriteLine("Измененный массив: ");
PrintArray(expArray);