namespace DotaParser52.Homeworks._21._03;

public class Solves
{
    public static T[] LQ1<T>(T[] array, int k)
    {
        if (array == null || array.Length == 0) return array;
    
        int n = array.Length;
        k = k % n;
    
        if (k == 0) return array.ToArray();
    
        return array.Skip(k).Concat(array.Take(k)).ToArray();
    }
    
    public static HashSet<(int x, int y)> LQ2(HashSet<(int x, int y)> points)
    {
        return points
            .SelectMany(point => MyLinq.Range(-1, 3)
                .SelectMany(dx => MyLinq.Range(-1, 3)
                    .Select(dy => (x: point.x + dx, y: point.y + dy))))
            .Where(p => !points.Contains(p))
            .Distinct()
            .ToHashSet();
    }
    
    public static IEnumerable<string> LQ3(IEnumerable<string> strings)
    {
        return strings.Where(s => 
            s.GroupBy(c => c)
                .All(g => g.Count() <= 2));
    }
}
