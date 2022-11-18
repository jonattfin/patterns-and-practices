using AlgorithmsDataStructures.Sorting.Methods;

namespace AlgorithmsDataStructures.Sorting;

public enum SortMethod
{
    SelectionSort,
    BubbleSort,
    InsertionSort,
    QuickSort
}

public static class SortFactory
{
    public static ISort<T> GetMethod<T>(SortMethod method)
    {
        return method switch
        {
            SortMethod.SelectionSort => new SelectionSort<T>(),
            SortMethod.BubbleSort => new BubbleSort<T>(),
            SortMethod.InsertionSort => new InsertionSort<T>(),
            SortMethod.QuickSort => new QuickSort<T>(),
            _ => throw new Exception("Method not defined")
        };
    }
}