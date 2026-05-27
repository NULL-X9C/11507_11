namespace DotaParser52.Homeworks._14._03;

public class LogFilter
{//я бы в AnalazeLog третий параметр pattern добавил, но чтобы было по тз сделаю в этом классе через конструктор и передам в метод поле
    private string _Pattern{get; }

    public LogFilter(string pattern)
    {
        _Pattern = pattern;
    }
    public bool Filter(string text)
    {
        if (text.Contains(_Pattern))
            return true;
        return false;
    }
    
}