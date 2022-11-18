namespace AlgorithmsDataStructures.Sorting;

public abstract class BaseSort<T> : ISort<T>
{
    public abstract void Sort(T[] array, Func<T, T, int> comparer);
    public abstract string Name { get; }

    protected static void Swap(T[] array, int aIndex, int bIndex)
    {
        (array[aIndex], array[bIndex]) = (array[bIndex], array[aIndex]);
    }
}