// Задача 59: Из двумерного массива целых чисел удалить строку и столбец, на пересечении которых расположен наименьший элемент.

using System;
using static System.Console;
Clear();

WriteLine("Исходный массив:");
int[,] array = new int[,] {
    {5,8,6,2},
    {4,4,5,6},
    {7,9,1,3},
    {2,7,3,5}
    };
PrintArray(array);
WriteLine($"Минимальный элемент находится в строке {FindMinIndex(array)[0] + 1} и в столбце {FindMinIndex(array)[1] + 1}");
WriteLine("Новый массив:");
PrintArray(RemoveArr(array, FindMinIndex(array)));


int[,] RemoveArr(int[,] arr, int[] minID)
{
    int[,] NewArray = new int[arr.GetLength(0) - 1, arr.GetLength(1) - 1];

    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (i == minID[0] || j == minID[1]) continue;
            if (i < minID[0])
            {
                if (j < minID[1]) NewArray[i, j] = arr[i, j];
                else NewArray[i, j == 0 ? 0 : j - 1] = arr[i, j];
            }
            else
            {
                if (j < minID[1]) NewArray[i == 0 ? 0 : i - 1, j] = arr[i, j];
                else NewArray[i == 0 ? 0 : i - 1, j == 0 ? 0 : j - 1] = arr[i, j];
            }

        }
    return NewArray;
}

int[] FindMinIndex(int[,] arr)
{
    int[] indexArr = { 0, 0 };
    int min = arr[0, 0];
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
            if (min > arr[i, j])
            {
                min = arr[i, j];
                indexArr[0] = i;
                indexArr[1] = j;
            }
    return indexArr;
}

void PrintArray(int[,] newArray)
{
    for (int i = 0; i < newArray.GetLength(0); i++)
    {
        for (int j = 0; j < newArray.GetLength(1); j++)
        {
            Write($"{newArray[i, j]} ");
        }
        WriteLine();
    }
}