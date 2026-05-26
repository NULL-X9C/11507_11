using System.Reflection;
using ReflectionClass.Homework.Utils.Validators.Abstraction;

namespace DotaParser52.Homeworks._23._05.Utils.Validators.Implementation;

public class UniversalValidator : IValidator
{
    /// <summary>
    /// Универсальный метод, который валидирует ВООБЩЕ любой объект на основе его атрибутов.
    /// </summary>
    public bool Validate(object? obj, out List<string> errors)
    {
        errors = new List<string>();
        // : Проверить на null
        if (obj is null)
        {
            errors.Add("Object is null");
        }

        // : ШАГ 1. Получить тип объекта
        var type = obj?.GetType();

        // : ШАГ 2. Извлечь все свойства
        PropertyInfo[]? properties = type?.GetProperties();
            
        // : ШАГ 3. Получать все значения свойств у ТЕКУЩЕГО экземпляра
        if (properties != null)
            foreach (var property in properties)
            {
                object? value = property.GetValue(obj);

                // : ШАГ 3.1 Проверять, обвешано ли свойство атрибутом MyRequired
                var requiredAttr = property.GetCustomAttribute<MyRequiredAttribute>();
                if (requiredAttr is null)
                {
                    errors.Add($"Атрибута {typeof(MyRangeAttribute)} нет");
                }

                // : ШАГ 3.2 Проверять, есть ли атрибут MyRange
                var rangeAttr = property.GetCustomAttribute<MyRangeAttribute>();
                if (rangeAttr is null)
                {
                    errors.Add($"Атрибута {typeof(MyRangeAttribute)} нет");
                }
            }
        else
        {
            errors.Add("Object is null");
        }

        return errors.Count == 0;
    }
}
public class MyRangeAttribute : Attribute
    {
        public MyRangeAttribute(int min, int max)
        {
        
        }
    }

[AttributeUsage(AttributeTargets.Property)]
public class MyRequiredAttribute : Attribute;