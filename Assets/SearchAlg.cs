using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchAlg : MonoBehaviour
{
    [Header("Array parameters")]
    public int ValueArray;
    [SerializeField] private int[] arrayToSearch;

    [Header("Search Input")]
    [SerializeField] private int keyToSearch;

    [Header("Search Output")]
    [SerializeField] private int keyFound;
    


    [ContextMenu("Gen & Sort Array")]
    void GenArray()
    {
        arrayToSearch = new int[ValueArray];
        for (int i = 0; i < arrayToSearch.Length; i++)
        {
            arrayToSearch[i] = UnityEngine.Random.Range(1, 10000);
        }
        Array.Sort(arrayToSearch);
    }

    [ContextMenu("Linear Search")]
    void LinearSearch()
    {
        keyFound = LinearSearch<int>(arrayToSearch, keyToSearch);
    }

    [ContextMenu("Binary Search")]
    void BinarySearch()
    {
        keyFound = BinarySearch(arrayToSearch, keyToSearch, 0, arrayToSearch.Length - 1);
    }

    [ContextMenu("Interpoliation Search")]
    void InterpolSearch()
    {
        keyFound = InterpolSearch(arrayToSearch, keyToSearch);
    }

    private void CheckArray<T>(T[] a)
    {
        if (a == null)
        {
            throw new ArgumentNullException("Массив не может быть нулевым");
        }

        if (a.Length == 0)
        {
            throw new ArgumentException("Длина массива должна быть больше нуля");
        }
    }

    // O(1) O(n)
    public int LinearSearch<T>(T[] a, T key) where T : struct, IEquatable<T>
    {
        CheckArray(a);

        for (int i = 0; i < a.Length; ++i)
        {
            // сравниваем текущее значение с искомым
            if (a[i].Equals(key))
            {
                return i;
            }
        }
        //если ничего не нашли
        return -1;
    }

    private int BinarySearch(int[] array, int searchedValue, int first, int last)
    {
        //границы сошлись
        if (first > last)
        {
            //элемент не найден
            return -1;
        }

        //средний индекс подмассива
        var middle = (first + last) / 2;
        //значение в средине подмассива
        var middleValue = array[middle];

        if (middleValue == searchedValue)
        {
            return middle;
        }
        else
        {
            if (middleValue > searchedValue)
            {
                //рекурсивный вызов поиска для левого подмассива
                return BinarySearch(array, searchedValue, first, middle - 1);
            }
            else
            {
                //рекурсивный вызов поиска для правого подмассива
                return BinarySearch(array, searchedValue, middle + 1, last);
            }
        }
    }


    //ДЗ Интерполяционный поиск элемента в массиве
    private int InterpolSearch(int[] array, int searchedValue)
    {
        CheckArray(array);

        int low = 0;
        int mid = -1;
        int high = array.Length - 1;
        int toFind = searchedValue;

        //границы сошлись
        if (low > high)
        {
            //элемент не найден
            Debug.Log("Поиск не успешен");
            return -1;
        } 
        
        while (array[low] < toFind && array[high] > toFind)
        {
            mid = low + ((toFind - array[low]) * (high - low)) / (array[high] - array[low]);
            if (array[mid] < toFind)
                low = mid + 1;
            else if (array[mid] > toFind)
                high = mid - 1;
            else if (toFind == array[mid])
            {
                Debug.LogWarningFormat($"Элемент {toFind} найден на позиции {mid + 1}\n");
                return mid + 1;
            }
        }
        return mid + 1;
    }
}
