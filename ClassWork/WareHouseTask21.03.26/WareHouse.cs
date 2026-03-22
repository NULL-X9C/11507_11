namespace DotaParser52.ClassWork;

using System.Text.Json;

    public class Product
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Price)}: {Price},  {nameof(Count)}: {Count}";
        }
    }
    
    public class ProductList
    {
        public List<Product> Products = new List<Product>
        {
            new Product()
            {
                Name = "cucumber",
                Price = 100m,
                Count = 2
            },
            new Product()
            {
                Name = "vodkaSouse",Price = 200m,Count = 3
            },
            new Product()
            {
                Name = "bread",
                Price = 60m,
                Count = 4
            }
        };
        public List<Product> UsersProducts = new();
    }
    
    public class FileManager
    {
        public void SaveFile(string fileName, List<Product> products)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            
            string currentDir = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDir, fileName);
            var contentt = JsonSerializer.Serialize(products, options);
            File.WriteAllText(filePath, contentt);
        }
    
        public List<Product> ReadFile(string fileName)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            
            string currentDir = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDir, fileName);
    
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл {fileName} не найден. Будет создан новый список.");
                return new List<Product>();
            }
    
            try
            {
                var jsonContent = File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<List<Product>>(jsonContent, options);
                
                return products ?? new List<Product>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return new List<Product>();
            }
        }
    }