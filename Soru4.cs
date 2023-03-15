using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[10000];
        Random rnd = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(10000);
        }

        // Merge Sort
        int[] arr1 = (int[])arr.Clone();
        Stopwatch stopwatch1 = new Stopwatch();
        stopwatch1.Start();

        MergeSort(arr1, 0, arr1.Length - 1);

        stopwatch1.Stop();
        Console.WriteLine("Merge Sort çalışma süresi: " + stopwatch1.ElapsedMilliseconds + "ms");

        // Bubble Sort (BruteForce)
        int[] arr2 = (int[])arr.Clone();
        Stopwatch stopwatch2 = new Stopwatch();
        stopwatch2.Start();

        BubbleSort(arr2);

        stopwatch2.Stop();
        Console.WriteLine("Bubble Sort (BruteForce) çalışma süresi: " + stopwatch2.ElapsedMilliseconds + "ms");
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
        {
            L[i] = arr[left + i];
        }
        for (int j = 0; j < n2; j++)
        {
            R[j] = arr[mid + 1 + j];
        }

        int k = left;
        int p = 0, q = 0;

        while (p < n1 && q < n2)
        {
            if (L[p] <= R[q])
            {
                arr[k] = L[p];
                p++;
            }
            else
            {
                arr[k] = R[q];
                q++;
            }
            k++;
        }

        while (p < n1)
        {
            arr[k] = L[p];
            p++;
            k++;
        }

        while (q < n2)
        {
            arr[k] = R[q];
            q++;
            k++;
        }
    }

    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}
