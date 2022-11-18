namespace AlgorithmsDataStructures.Sorting.Methods;

public class InsertionSort<T> : BaseSort<T>
{
    public override void Sort(T[] array, Func<T, T, int> comparer)
    {
        for (var i = 0; i < array.Length; i++)
        {
            var j = i;
            while (j > 0 && comparer(array[j - 1], array[j]) < 0)
            {
                Swap(array, j, j - 1);
                j--;
            }
        }
    }

    public override string Name { get; } = "Insertion";
}