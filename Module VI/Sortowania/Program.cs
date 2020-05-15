using System;
using System.Diagnostics;

namespace Sortowania
{
    class Program
    {
        static void Main(string[] args)
        {
            var smallData = new int[1000];
            var bigData = new int[100000];
            GenerateRandomizedArray(smallData, 1000);
            GenerateRandomizedArray(bigData, 100000);

            var sorts = new[]{"QuickSort", "ShellSort", "HeapSort", "BubbleSort", "MergeSort", "CountSort"};
            Stopwatch timerSw = new Stopwatch();


            Console.WriteLine("[#] Testowanie na małych bazach:");

            for (int i = 0; i < 6; i++)
            {
                timerSw.Start();
                switch (i)
                {
                    case 0:
                        QuickSort(smallData, 0, smallData.Length - 1);
                        break;
                    case 1:
                        ShellSort(smallData, smallData.Length);
                        break;
                    case 2:
                        HeapSort(smallData, smallData.Length);
                        break;
                    case 3:
                        BubbleSort(smallData);
                        break;
                    case 4:
                        MergeSort(smallData);
                        break;
                    case 5:
                        CountSort(smallData);
                        break;
                    default:
                        break;
                }
                timerSw.Stop();
                Console.WriteLine($"{sorts[i]} time: " + timerSw.Elapsed);
                timerSw.Reset();
            }


            Console.WriteLine("\n[#] Testowanie na dużych bazach:");
            for (int i = 0; i < 6; i++)
            {
                timerSw.Start();
                switch (i)
                {
                    case 0:
                        QuickSort(bigData, 0, bigData.Length - 1);
                        break;
                    case 1:
                        ShellSort(bigData, bigData.Length);
                        break;
                    case 2:
                        HeapSort(bigData, bigData.Length);
                        break;
                    case 3:
                        BubbleSort(bigData);
                        break;
                    case 4:
                        MergeSort(bigData);
                        break;
                    case 5:
                        CountSort(bigData);
                        break;
                    default:
                        break;
                }
                timerSw.Stop();
                Console.WriteLine($"{sorts[i]} time: " + timerSw.Elapsed);
                timerSw.Reset();
            }

            Console.ReadKey();
        }
        



        private static void GenerateRandomizedArray(int[] arr, int range)
        {
            Random rnd = new Random();
            for (int i = 0; i < range; i++)
            {
                arr[i] = rnd.Next();
            }
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = array[(left + right) / 2];
            while (i < j)
            {
                while (array[i] < pivot) i++;
                while (array[j] > pivot) j--;
                if (i <= j)
                {

                    int tmp = array[i];
                    array[i++] = array[j];
                    array[j--] = tmp;
                }
            }
            if (left < j) QuickSort(array, left, j);
            if (i < right) QuickSort(array, i, right);
        }

        private static void ShellSort(int[] arr, int n)
        {
            var pos = 3;
            while (pos > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    var j = i;
                    var temp = arr[i];
                    while ((j >= pos) && (arr[j - pos] > temp))
                    {
                        arr[j] = arr[j - pos];
                        j -= pos;
                    }
                    arr[j] = temp;
                }
                if (pos / 2 != 0)
                    pos /= 2;
                else if (pos == 1)
                    pos = 0;
                else
                    pos = 1;
            }
        }

        private static void HeapSort(int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                Heap(arr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heap(arr, i, 0);
            }
        }

        private static void Heap(int[] arr, int n, int i)
        {
            while (true)
            {
                int largest = i;
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                if (left < n && arr[left] > arr[largest]) largest = left;
                if (right < n && arr[right] > arr[largest]) largest = right;
                if (largest != i)
                {
                    int swap = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = swap;
                    i = largest;
                    continue;
                }
                break;
            }
        }

        private static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] <= arr[j + 1]) continue;
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }

        }

        private static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
                return array;

            int midPoint = array.Length / 2;
            var left = new int[midPoint];

            var right = array.Length % 2 == 0 ? new int[midPoint] : new int[midPoint + 1];

            for (int i = 0; i < midPoint; i++)
                left[i] = array[i];

            int x = 0;

            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            left = MergeSort(left);
            right = MergeSort(right);

            var result = Merge(left, right);
            return result;
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            var result = new int[resultLength];
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

        private static void CountSort(int[] arr)
        {
            int n = arr.Length;
            var output = new int[n];
            var count = new int[n];

            for (int i = 0; i < 1000; ++i)
                count[i] = 0;

            for (int i = 0; i < n-2; ++i)
                count[i]++;

            for (int i = 1; i < 1000; ++i)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 1; i--)
            {
                output[i - 1] = arr[i-1];
                --count[i];
            }
        }

    }
}
