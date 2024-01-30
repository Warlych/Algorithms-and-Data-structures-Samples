int[] testArrInt = { 1, 2, 3, 4, 5, 6, 7 };
double[] testArrDouble = { 10.5, 11.5, 12.3, 26.3, 64.2 };

int BinarySearch<T>(T[] array, T findItem) where T : IComparable<T>
{
    if (array.Length.Equals(0))
        throw new InvalidOperationException("Массив не содержит элементов");

    int left = 0, right = array.Length - 1;

    while (left <= right)
    {
        int middle = left + (right - left) / 2;

        if (array[middle].Equals(findItem))
            return middle;
        else if (array[middle].CompareTo(findItem) < 0)
            left = middle + 1;
        else
            right = middle - 1;
    }
    
    return -1;
}

Console.WriteLine($"Индекст элемента 3: {BinarySearch(testArrInt, 3)}");
Console.WriteLine($"Индекст элемента 64.2: {BinarySearch(testArrDouble, 64.2)}");