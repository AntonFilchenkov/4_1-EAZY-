using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Тестируем массив для string
        CustomArray<string> stringArray = new CustomArray<string>();
        stringArray.Add("shopper");
        stringArray.Add("sneakers");
        stringArray.Add("cap");
        stringArray.Add("t-shirt");
        TestArray(stringArray);
        Console.WriteLine("-> Проверка на наличие элемента /cap/:");
        Console.WriteLine(stringArray.CheckFirst(item => item == "cap"));

        // Тестируем массив для int
        CustomArray<int> intArray = new CustomArray<int>();
        intArray.Add(7);
        intArray.Add(95);
        intArray.Add(12);
        intArray.Add(5);
        TestArray(intArray);
        Console.WriteLine("-> Первый элемент, который в поиске оказался больше 7:");
        Console.WriteLine(intArray.FindFirst(item => item > 7));

        Console.ReadLine();
    }

    static void TestArray<T>(CustomArray<T> array)
    {
        Console.WriteLine();
        Console.WriteLine("Тестируем массив для типа " + typeof(T).Name);

        // Выводим массив до сортировки
        Console.WriteLine("-> Массив перед сортировкой:");
        array.Print();

        // Сортируем массив
        array.Sort();

        // Выводим массив после сортировки
        Console.WriteLine("-> Массив после сортировки:");
        array.ForeachDo(item => Console.Write(item + " "));
        Console.WriteLine();

        // Получаем минимальное и максимальное значения
        Console.WriteLine($"[↓] Минимум: {array.Min()}");
        Console.WriteLine($"[↑] Максимум: {array.Max()}");
    }
}