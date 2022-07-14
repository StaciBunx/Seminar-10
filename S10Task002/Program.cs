// Задача 61: Показать треугольник Паскаля. *Сделать вывод в виде равнобедренного треугольника.

using System;
using static System.Console;
Clear();

Write("Введите количество строк: ");
int num = Convert.ToInt32(ReadLine());
for (int i = 0; i < num; i++)
{
    for (int j = num; j > i; j--)
    {
        Write(" ");
    }
    int value = 1;
    for (int j = 0; j <= i; j++)
    {
        Write($"{value} ");
        value = value * (i - j) / (j + 1);
    }
    WriteLine();
}