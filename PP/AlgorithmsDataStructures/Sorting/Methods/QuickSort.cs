namespace AlgorithmsDataStructures.Sorting.Methods;

public class QuickSort<T> : BaseSort<T>
{
    public override void Sort(T[] array, Func<T, T, int> comparer)
    {
        Sort(array, 0, array.Length - 1, comparer);
    }

    private static void Sort(T[] array, int lower, int upper, Func<T, T, int> comparer)
    {
        if (lower < upper)
        {
            var p = Partition(array, lower, upper, comparer);
            Sort(array, lower, p, comparer);
            Sort(array, p + 1, upper, comparer);
        }
    }

    private static int Partition(T[] array, int lower, int upper, Func<T, T, int> comparer)
    {
        var i = lower;
        var j = upper;

        var pivot = (lower + upper) / 2;

        do
        {
            while (comparer(array[i], array[pivot]) < 0)
                i++;

            while (comparer(array[j], array[pivot]) > 0)
                j--;

            if (i >= j) 
                break;
            
            Swap(array, i, j);
        } while (i <= j);

        return j;
    }

    public override string Name { get; } = "QuickSort";
}