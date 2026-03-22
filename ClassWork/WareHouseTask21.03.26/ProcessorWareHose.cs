namespace DotaParser52.ClassWork;

public class ProcessorWareHose
{
    public void StartProcess()
    {
        // var products = new ProductList().Products;
        // var fileManager = new FileManager();
        // fileManager.SaveFile("список товаров", products);

        var fileManager = new FileManager();
        var addProducts = new ProductAdder();
        addProducts.AddProduct();
        var product = fileManager.ReadFile("товары");
        addProducts.PrintProducts(product);
    }
}