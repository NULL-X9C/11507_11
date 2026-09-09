namespace ReflectionClass.Homework.Utils.MyMapper;

public interface IMapper
{
    void Map<TSource, TDest>(TSource source, TDest dest);
}