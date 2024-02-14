using System;

int[] testArrInt = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
double[] testArrDouble = { 12.5, 4.3, 5.7, 6.1, 7.9, 3.2, 1.0, 15.4, 2.8, 14.6, 13.7, 8.9, 9.2, 11.8, 10.3 };

void HeapSort<T> (T[] array) where T : IComparable<T>
{
    int length = array.Length;

    for (int i = length / 2 - 1; i >= 0; i--)
        Heapify(array, length, i);

    for (int i = length - 1; i >= 0; i--)
    {
        Swap(array, 0, i);
        Heapify(array, i, 0);
    }
}

void Heapify<T> (T[] array, int n, int i) where T : IComparable<T>
{
    int largest = i;

    int l = 2 * i + 1;
    int r = 2 * i + 2;

    if (l < n && array[l].CompareTo(array[largest]) > 0)
        largest = l;
    
    if (r < n && array[r].CompareTo(array[largest]) > 0)
        largest = r;
    
    if (largest != i)
    {
        Swap(array, i, largest);
        Heapify(array, n, largest);
    }
}

void Swap<T> (T[] array, int lastPosition, int newPosition)
{
    T temp = array[lastPosition];
    array[lastPosition] = array[newPosition];
    array[newPosition] = temp;
}

HeapSort(testArrInt);
HeapSort(testArrDouble);