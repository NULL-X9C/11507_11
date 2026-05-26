namespace ReflectionClass.Homework.Utils.Validators.Abstraction;

public interface IValidator
{
    bool Validate(object obj, out List<string> errors);
}