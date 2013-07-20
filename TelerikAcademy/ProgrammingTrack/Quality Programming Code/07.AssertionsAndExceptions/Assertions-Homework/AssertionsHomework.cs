using System;
using System.Diagnostics;
using System.Linq;

public class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        // Here we are throwing an exception and not an assertion because the method is
        // public and could be passed spurious data by the user.
        if (arr == null)
        {
            throw new ArgumentException("Array must be initialized.");
        }
        else if (arr.Length == 0)
        {
            throw new ArgumentException("Cannot sort an empty array.");
        }

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        for (int i = 0; i < arr.Length - 1; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "The array is not sorted.");
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is not initialized.");
        Debug.Assert(arr.Length > 0, "Array is empty.");
        Debug.Assert(value != null, "The searched value is not initialized.");

        for (int i = 0; i < arr.Length - 1; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "The array is not sorted.");
        }

        var valueIndex = BinarySearch(arr, value, 0, arr.Length - 1);
        return valueIndex;
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is not initialized.");
        Debug.Assert(arr.Length > 0, "Array is empty.");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Start index outside the boundaries of the array.");
        Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "End index outside the boundaries of the array.");
        Debug.Assert(startIndex < endIndex, "Start index must preceed the end index.");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        // Since we have already ensured that the startIndex and endIndex are within the boundaries of the
        // array, we only need to check whether the minElementIndex is between the start and end indexes.
        Debug.Assert(minElementIndex >= startIndex && minElementIndex <= endIndex,
            "Incorrect identification of the minimal index");

        for (int i = 0; i < arr.Length; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[minElementIndex]) >= 0, "Incorrect identification of the minimal element.");
        }

        return minElementIndex;
    }

    // No need to assert anything in this method.
    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        // Although by design the method is called only from the other Binary Search method, some
        // of the assertions will be repeated in case another developer tries to use the method
        // in a different context.
        Debug.Assert(arr != null, "Array is not initialized.");
        Debug.Assert(arr.Length > 0, "Array is empty.");
        Debug.Assert(value != null, "The searched value is not initialized.");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Start index outside the boundaries of the array.");
        Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "End index outside the boundaries of the array.");
        Debug.Assert(startIndex < endIndex, "Start index must preceed the end index.");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // If this place in the code is reached, that means that the algorithm has not found the element
        // in the array. We will check via assertion if that is indeed the case.
        for (int i = 0; i < arr.Length; i++)
        {
            Debug.Assert(arr[i].CompareTo(value) != 0, "The value is not found although it is in the array");
        }

        // Searched value not found
        return -1;
    }

    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
