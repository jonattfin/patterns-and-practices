// See https://aka.ms/new-console-template for more information

using AlgorithmsDataStructures.Sorting;

var originalArray = new[] { 5, 3, 2, 6, 4, 1, 3, 7 };

var ascComparer = new Func<int, int, int>((a, b) => a.CompareTo(b));
var descComparer = new Func<int, int, int>((a, b) => b.CompareTo(a));

// SelectionSort
Sort(originalArray, SortMethod.SelectionSort, ascComparer);
Sort(originalArray, SortMethod.SelectionSort, descComparer);

// BubbleSort
Sort(originalArray, SortMethod.BubbleSort, ascComparer);
Sort(originalArray, SortMethod.BubbleSort, descComparer);

// InsertionSort
Sort(originalArray, SortMethod.InsertionSort, ascComparer);
Sort(originalArray, SortMethod.InsertionSort, descComparer);

// QuickSort
Sort(originalArray, SortMethod.BubbleSort, ascComparer);
Sort(originalArray, SortMethod.BubbleSort, descComparer);

Console.WriteLine("Press any key to continue...");
Console.ReadKey();

void Sort<T>(T[] array, SortMethod sortMethod, Func<T, T, int> comparer) where T : IComparable
{
    var method = SortFactory.GetMethod<T>(sortMethod);
    
    Console.WriteLine($"# Method: {method.Name},  #");
    Console.WriteLine("Before {0}", string.Join(",", array));

    // the magic happens here
    method.Sort(array, comparer);

    Console.WriteLine("After {0}", string.Join(",", array));
}