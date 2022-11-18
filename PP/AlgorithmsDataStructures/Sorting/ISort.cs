namespace AlgorithmsDataStructures.Sorting;

public interface ISort<T>
{
    public void Sort(T[] array, Func<T, T, int> comparer);
    string Name { get; }
}