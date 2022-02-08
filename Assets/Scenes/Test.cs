using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int[] array;

    int a;
    void SimpleAlg()
    {
        a = array[0];
        int b =0;
        for (int i = 1; i < array.Length; i++) // n!= n
        {
            for (int j = 0; j < array.Length; j++)
            {

            }
            if (array[i] < a)
            {
                a = array[i];
                b++;
                b++;
            }


        }
        int n =0, m =0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
            }
        }
    }


    void A(int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            b(m);
        }

        
        b(n);
    }
    //O(n + m + n) = O(2n + m) = O(n+m)

    void b(int n)
    {
        for (int i = 0; i < n; i++)
        {

        }
    }
    // n == n
    // n = 1
    //  0         1
    // n = 10
    // 18   10
    // n = 100
     
}
