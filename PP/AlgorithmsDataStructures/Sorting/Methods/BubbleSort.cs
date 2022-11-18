namespace AlgorithmsDataStructures.Sorting.Methods;

public class BubbleSort<T> : BaseSort<T>
{
    public override void Sort(T[] array, Func<T, T, int> comparer)
    {
        bool swapped;
        do
        {
            swapped = false;
            for (var i = 0; i < array.Length - 1; i++)
            {
                if (comparer(array[i + 1], array[i]) > 0) 
                    continue;
                
                Swap(array, i + 1, i);
                swapped = true;
            }
        } while (swapped);
    }

    public override string Name { get; } = "Bubble";
}