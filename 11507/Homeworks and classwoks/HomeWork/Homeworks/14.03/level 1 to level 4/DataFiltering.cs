namespace HomeWork.Homeworks._14._03.level_1_to_level_4;

#region Abstraction
public interface IDataFilter<T>
{
    public IEnumerable<T> Filter(IEnumerable<T> items, params Predicate<T>[] predicates);
}
#endregion

public class DataFiltering : IDataFilter<Employee>
{
    public IEnumerable<Employee> Filter(IEnumerable<Employee> items, params Predicate<Employee>[] predicates)
    {
        //return items.Where(item => predicates.All(p => p(item)));
        foreach (var item in items)
        {
            if (predicates.All(p => p(item)))
            {
                yield return item;
            }
        }
    }
}

public class Employee()
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Experience { get; set; }
    public decimal Salary { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName ?? ""} {Email} Опыт: {Experience} Salary: {Salary}";
    }
}