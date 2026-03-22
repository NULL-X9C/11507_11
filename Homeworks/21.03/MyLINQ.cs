namespace DotaParser52.Homeworks._21._03;

public static class MyLinq
{
    public static int Count<TSource>(
        this IEnumerable<TSource> source)
    {
        int count = 0;
        foreach (var item in source)
        {
            count++;
        }
        return count;
        
    }
    public static IEnumerable<int> Range(int start, int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return start + i;
        }
    }
    
    public static IEnumerable<TResult> Select<TSource, TResult>(
        this IEnumerable<TSource> source, 
        Func<TSource, TResult> selector)
    {
        foreach (var item in source)
        {
            yield return selector(item);
        }
    }
    
    public static IEnumerable<TResult> SelectMany<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, IEnumerable<TResult>> selector)
    {
        foreach (var item in source)
        {
            foreach (var result in selector(item))
            {
                yield return result;
            }
        }
    }
    
    public static IEnumerable<TSource> Where<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
    
    public static IEnumerable<TSource> Distinct<TSource>(
        this IEnumerable<TSource> source)
    {
        var seen = new HashSet<TSource>();
        
        foreach (var item in source)
        {
            if (!seen.Contains(item))
            {
                seen.Add(item);
                yield return item;
            }
        }
    }
    
    public static HashSet<TSource> ToHashSet<TSource>(
        this IEnumerable<TSource> source)
    {
        return new HashSet<TSource>(source);
    }
    
    public static bool All<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
    {
        foreach (var item in source)
        {
            if (!predicate(item))
            {
                return false;
            }
        }
        return true;
    }
}