using System;
using System.Collections;
using System.Collections.Generic;

class CustomArray<T>
{
    private T[] array;
    private int count;

    // Массив
    //private T[] array;

    // Емкость - размер массива.
    public int Capacity => array.Length;

    // Фактический размер - количество заполненных
    // элементов в массиве.
    public int Count => count;

    // -> Создание массива заданной емкости.
    // Конструктор с указанием длины массива.
    public CustomArray(int capacity)
    {
        // Массив
        count = 0;
        array = new T[capacity];
    }

    // -> Создание массива с емкостью по умолчанию
    // Конструктор по умолчанию.
    public CustomArray() : this(10)
    {

    }

    // -> Получение минимального/максимального элемента массива.
    // Найти максимум.
    public T Max()
    {
        if (count == 0)
            throw new InvalidOperationException("Массив пуст.");

        T max = array[0];
        for (int i = 1; i < count; i++)
        {
            if (Comparer<T>.Default.Compare(array[i], max) > 0)
                max = array[i];
        }
        return max;
    }

    // Найти минимум.
    public T Min()
    {
        if (count == 0)
            throw new InvalidOperationException("Массив пуст.");

        T min = array[0];
        for (int i = 1; i < count; i++)
        {
            // Выдает "> 0", если левый элемент больше правого.
            // Выдает "= 0", если левый элемент равен правому.
            // Выдает "< 0", если левый элемент меньше правого.
            if (Comparer<T>.Default.Compare(array[i], min) < 0)
                min = array[i];
        }
        return min;
    }

    // -> Добавление элемента в массив.
    public void Add(T element)
    {
        // Проверяем, есть ли свободная ячейка в массиве.
        // Если есть ячейка, то вставляем в первую попавшуюся свободную ячейку.
        if (Count != Capacity)
        {
            array[Count] = element;
            count++;
            return;
        }

        T[] newArray = new T[2 * Capacity + 1];
        System.Array.Copy(array, newArray, Capacity);


        int insertIndex = Capacity;
        array = newArray;


        array[insertIndex] = element;

        count++;

    }

    // -> Сортировка массива.
    public void Sort()
    {
        System.Array.Sort(array, 0, count);
    }

    // -> Переворот массива.
    public void Reverse()
    {
        for (int i = 0; i < count / 2; i++)
        {
            T temp = array[i];
            array[i] = array[count - i - 1];
            array[count - i - 1] = temp;
        }
    }

    // -> Удалить элемент.
    public void Remove(T element)
    {

        int indexOfElement = Array.IndexOf(array, element);
        if (indexOfElement == -1) throw new Exception("Нет такого элемента");

        for (int i = indexOfElement; i < Count - 1; i++)
        {
            array[i] = array[i + 1];
        }

        count--;
    }

    // -> Проверка выполнения переданного условия хотя бы одного элемента массива.
    // Делегат "Predicate" - это делегат, который принимает
    // один параметр и возвращает bool.
    public bool CheckFirst(Predicate<T> condition)
    {
        for (int i = 0; i < count; i++)
        {
            if (condition(array[i]))
            {
                return true;
            }
        }
        return false;
    }

    // -> Получение первого элемента массива, удовлетворяющих переданному условию.
    public T FindFirst(Predicate<T> condition)
    {
        for (int i = 0; i < count; i++)
        {
            if (condition(array[i]))
            {
                return array[i];
            }
        }
        return default;
    }

    // -> Получение элементов массива, удовлетворяющих переданному условию.
    // Возвращает список элементов, которые удовлетворяют условию.
    public T[] FindAll(Predicate<T> condition)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < count; i++)
        {
            if (condition(array[i]))
            {
                list.Add(array[i]);
            }
        }
        return list.ToArray();
    }

    // -> Вывод массива.
    public void Print()
    {
        foreach (T item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // -> Применение переданного действия ко всем элементам массива.
    // Делегат "Action" - это делегат, который принимает действие,
    // которое необходимо выполнить над элементами массива.
    public void ForeachDo(Action<T> action)
    {
        for (int i = 0; i < count; i++)
        {
            action(array[i]);
        }
    }
}
