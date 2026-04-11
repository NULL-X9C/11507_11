namespace DotaParser52.ControlWork.Cw1;

public static class MathUtils
{
    public static T FindMedian<T>(T a, T b, T c) where T : IComparable<T>
    {
        T[] arr = { a, b, c };
        return FindArrayMedian(arr);
    }

    public static T FindArrayMedian<T>(T[] array) where T : IComparable<T> 
    {
        Array.Sort(array);
        if (array.Length % 2 != 0)
        {
            return array[array.Length / 2];
        }
        else
        {
            return array[array.Length / 2 - 1];
        }
    }
}