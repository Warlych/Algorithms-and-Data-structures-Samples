using System;

int[] testArrInt = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
double[] testArrDouble = { 12.5, 4.3, 5.7, 6.1, 7.9, 3.2, 1.0, 15.4, 2.8, 14.6, 13.7, 8.9, 9.2, 11.8, 10.3 };
void QSort<T>(T[] array, int low, int high) where T : IComparable<T>
{
    if (low < high)
    {
        int pivot = Partition(array, low, high);

        QSort(array, low, pivot - 1);
        QSort(array, pivot + 1, high);
    }
}

int Partition<T>(T[] array, int low, int high) where T : IComparable<T>
{
    T pivot = array[high];
    int i = low - 1;

    for (int j = low; j < high; j++)
    {
        if (array[j].CompareTo(pivot) < 0)
        {
            i++;
            Swap(ref array[i], ref array[j]);
        }
    }
    
    Swap(ref array[i + 1], ref array[high]);
    return i + 1;
}

void Swap<T>(ref T left, ref T right)
{
    T temp = left; left = right; right = temp;
}

QSort(testArrInt, 0, testArrInt.Length - 1);
QSort(testArrDouble, 2, testArrDouble.Length - 1);

/// <feature>
/// if you need the pivot element to be taken from the middle of the array, then you need modify Partition<T>(...):
/// int pivotIndex = (low + high) / 2;
/// T pivot = array[pivotIndex];
/// int i = low;
/// Swap(ref array[pivotIndex], ref array[high]);
/// for (int j = low; j < high; j++)
/// {
///  if (array[j].CompareTo(pivot) < 0)
///  {
///     Swap(ref array[i], ref array[j]);
///     i++;
///  }
/// }
///
/// Swap(ref array[i], ref array[high]);
/// return i;
/// 
/// </feature>