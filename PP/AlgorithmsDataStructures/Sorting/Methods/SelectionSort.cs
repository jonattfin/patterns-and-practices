namespace AlgorithmsDataStructures.Sorting.Methods;

public class SelectionSort<T> : BaseSort<T>
{
    public override string Name => "Selection";

    public override void Sort(T[] array, Func<T, T, int> comparer)
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            var minIndex = i;
            var minElement = array[i];
            for (var j = i + 1; j < array.Length; j++)
            {
                if (comparer(minElement, array[j]) < 0)
                    continue;

                minIndex = j;
                minElement = array[j];
            }

            Swap(array, i, minIndex);
        }
    }
}