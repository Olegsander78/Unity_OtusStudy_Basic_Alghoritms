using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour
{
    public int ValueArray;
    [SerializeField] private int[] arrayToSort;
    

    [ContextMenu("Generator Array")]
    void GenArray()
    {
        arrayToSort = new int[ValueArray];
        for (int i = 0; i < arrayToSort.Length; i++)
        {
            arrayToSort[i] = Random.Range(1, 10000);
        }
    }

    void Swap(ref int e1, ref int e2)
    {
        var temp = e1;
        e1 = e2;
        e2 = temp;
    }

    int[] BubbleSort(int[] array)
    {
        var len = array.Length;
        for (var i = 1; i < len; i++)
        {
            for (var j = 0; j < len - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                }
            }
        }

        return array;
    } // O(n*n) O(n)

    [ContextMenu("Test sort")]
    void TestSort()
    {
        int[] arr = new int[50000];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Range(-10000, 10000);
        }

        float startTime = Time.realtimeSinceStartup;
        Debug.Log("Start " + Time.realtimeSinceStartup);
        BubbleSort(arr);
        Debug.Log("End " + Time.realtimeSinceStartup);

        Debug.Log("Total " + (Time.realtimeSinceStartup - startTime));

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Range(-10000, 10000);
        }

        startTime = Time.realtimeSinceStartup;
        Debug.Log("Start " + Time.realtimeSinceStartup);
        QuickSort(arr);
        Debug.Log("End " + Time.realtimeSinceStartup);

        Debug.Log("Total " + (Time.realtimeSinceStartup - startTime));
    }

    [ContextMenu("Bubble Sort")]
    void BubbleSort()
    {
        float startTime = Time.time;
        Debug.Log("Start " + Time.time);
        arrayToSort = BubbleSort(arrayToSort);
        Debug.Log("End " + Time.time);

        Debug.Log("Total " + (Time.time - startTime));
    }

    int Partition(int[] array, int minIndex, int maxIndex)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (array[i] < array[maxIndex])
            {
                pivot++;
                Swap(ref array[pivot], ref array[i]);
            }
        }

        pivot++;
        Swap(ref array[pivot], ref array[maxIndex]);
        return pivot;
    }

    int[] QuickSort(int[] array, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
        {
            return array;
        }

        var pivotIndex = Partition(array, minIndex, maxIndex);
        QuickSort(array, minIndex, pivotIndex - 1);
        QuickSort(array, pivotIndex + 1, maxIndex);

        return array;
    }

    int[] QuickSort(int[] array)
    {
        return QuickSort(array, 0, array.Length - 1);
    }

    [ContextMenu("Quick Sort")]
    void QuickSort()
    {
        float startTime = Time.time;
        Debug.Log("Start " + Time.time);
        arrayToSort = QuickSort(arrayToSort);
        Debug.Log("End " + Time.time);

        Debug.Log("Total " + (Time.time - startTime));
    }

    //ДЗ по алгоритмам 

    //Сортировка вставками https://programm.top/c-sharp/algorithm/array-sort/insertion-sort/
    //На сайте код с ошибкой,- первый элемент массива  не сортируется. Исправил.
    int[] InsertionSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var key = array[i];
            var j = i;
            while ((j > 0) && (array[j - 1] > key))
            {
                Swap(ref array[j - 1], ref array[j]);
                j--;
            }

            array[j] = key;
        }

        return array;
    }

    [ContextMenu("Insertion Sort")]
    void InsertionSort()
    {
        float startTime = Time.time;
        Debug.Log("Start Insertion Sort: " + Time.time);
        arrayToSort = InsertionSort(arrayToSort);
        Debug.Log("End Insertion Sort: " + Time.time);
        Debug.Log("Total Insertion Sort: " + (Time.time - startTime));
        string arrString = "";
        for (int i = 0; i < arrayToSort.Length; i++)
        {
            arrString += arrayToSort[i] + ";";
        }
        Debug.Log(arrString);
    }

}
