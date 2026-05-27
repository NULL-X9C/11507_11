namespace DotaParser52.Homeworks._14._03.level_1_to_level_4;

public static class Extension
{
        public static void ForEachWithIndex<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            int i = 0;
            foreach (T item in source)
            {
                action(item, i);
                i++;
            }
        }
}