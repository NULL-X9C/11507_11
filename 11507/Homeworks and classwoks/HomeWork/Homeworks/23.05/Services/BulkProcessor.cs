using ReflectionClass.Homework.DTOs;
using ReflectionClass.Homework.Utils.MyMapper;
using ReflectionClass.Homework.Utils.Validators.Abstraction;

namespace ReflectionClass.Homework.Services;

public class BulkProcessor
{
    private readonly IValidator _validator;
    private readonly IMapper _mapper;
    
    // Зависимости внедряются через конструктор (DI)
    public BulkProcessor(IValidator validator, IMapper mapper)
    {
        _validator = validator;
        _mapper = mapper;
    }
    
    public List<UserDto> ProcessParallel(List<object> rawItems, out List<string> allErrors)
    {
        var validDtos = new List<UserDto>();
        var errors = new List<string>();
        
        var locker = new object();

        // : Распараллелить через Parallel.ForEach
        Parallel.ForEach(rawItems, item =>
        {
            if (_validator.Validate(item, out List<string> itemErrors))
            {
                var dto = new UserDto();
                _mapper.Map(item, dto);
                lock (locker)
                {
                    validDtos.Add(dto);
                }
            }
            else
            {
                lock (locker)
                {
                    errors.AddRange(itemErrors);
                }
            }
        });

        allErrors = errors;
        return validDtos;
    }
}