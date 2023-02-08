using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;


internal class Program
{
    private static void Main(string[] args)
    {
        
        //ProductTest();
        //IoC
        //CategoryTest();
        ProductManager productManager1 = new ProductManager(new EfProductDal());
        foreach (var product in productManager1.GetProductDetails())
        {
            Console.WriteLine(product.ProductName + " ---> " + product.CategoryName );
        }




    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetAll())
        {
            Console.WriteLine(category.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        foreach (var product in productManager.GetByUnitPrice(50, 100))
        {
            Console.WriteLine(product.ProductName);
        }
    }
}