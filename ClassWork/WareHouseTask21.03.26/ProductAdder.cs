namespace DotaParser52.ClassWork;

public class ProductAdder
{
    public void AddProduct()
    {
        var productList = new ProductList();
        var products = productList.UsersProducts;
        
        bool stop = false;
        do
        {
            Console.WriteLine("Enter Product Name:");
            string? name;
            while (true)
            {
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) Console.WriteLine("Enter Product Name:");
                else 
                    break;
            }

            Console.WriteLine("Enter Product Price:");
            decimal price;
            while (true)
            {
                if (!decimal.TryParse(Console.ReadLine(), out price)) Console.WriteLine("Enter Product Price:");
                else
                {
                    break;
                }
            }

            Console.WriteLine("Enter Product Count:");
            int count;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out count)) Console.WriteLine("Enter Product Count:");
                else
                  break;
            }
            products.Add(new Product(){Name = name, Price = price, Count = count});
            Console.WriteLine("Do you wanna add another product? Y/N, def: Y");
            if (Console.ReadLine().ToLower() == "n") stop = true;
            
        } while (stop is false);
        var fileManager = new FileManager();
        fileManager.SaveFile("товары", products);
    }

    public void RemoveProduct(List<Product> products)
    {
        Console.WriteLine("Enter the name of the product to be removed:");
        string? name;
        while (true)
        {
            name = Console.ReadLine()?.ToLower();
            if (string.IsNullOrWhiteSpace(name)) Console.WriteLine("Enter Product Name:");
            else 
                break;
        }
        products.RemoveAll(product => product.Name.ToLower() == name);
        var fileManager = new FileManager();
        fileManager.SaveFile("товары", products);
        
    }

    public void PrintProducts(List<Product> products)
    {
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
}