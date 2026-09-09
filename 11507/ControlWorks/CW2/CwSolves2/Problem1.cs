using System.Reflection;

namespace CwSolves2;

public class TypeFactory
{
    public static object CreateAndFill(Type type, Dictionary<string, object> values)
    {
        object? obj = Activator.CreateInstance(type);
        if (obj is null)
            throw new NullReferenceException("Object is null");
        
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            if (values.TryGetValue(property.Name, out var value))
            {
               property.SetValue(obj, value);

            }
        }
        return obj;
    }
}