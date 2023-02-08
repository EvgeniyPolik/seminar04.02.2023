using System.Text;

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

string IntArrayToString(int[] line, string sep = " ")  // Сформировать строку из строки массива
{
    StringBuilder tmpLine = new StringBuilder();
    int len = line.Length;
    for (int i = 0; i < len; i++)
    {
        tmpLine.Append(line[i]);
        if (i < len - 1)
            tmpLine.Append(sep);
    }
    return tmpLine.ToString();
}

IEnumerable<int[]> SwipeLine(int[,] expArray)  // Перечислитель строк
{
    var countLine = expArray.GetLength(0);
    var countColumn = expArray.GetLength(1);
    for (int i = 0; i < countLine; i++)
    {
        int[] line = new int[countColumn];
        for (int j = 0; j < countColumn; j++)
            line[j] = expArray[i, j];
        yield return line;
    }
}

int GetSumLine(int[] line)  // Подсчет суммы элементов в строке
{
    int len = line.Length;
    int sum = 0;
    for (int i = 0; i < len; i++)
        sum += line[i];
    return sum;
}

void PrintSumLine(int[,] expArray)
{
    foreach (var line in SwipeLine(expArray))
    {
        var sum = GetSumLine(line);
        var strLine = IntArrayToString(line);
        Console.WriteLine($"Сумма строки: {strLine} равна {sum}");
    }

}

var arrayDimension = GetIntFromConsole("Введите размерность массива: ");
int[,] expArray = GetIntRandomArray(arrayDimension);
PrintArray(expArray, "Сформированный массив: ");
PrintSumLine(expArray);