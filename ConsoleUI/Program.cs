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
        //ProductManager productManager1 = new ProductManager(new EfProductDal());

        //var result = productManager1.GetProductDetails();

        //if (result.Success == true ) 
        //{ 
        //    foreach (var product in result.Data)
        //    {
        //    Console.WriteLine(product.ProductName + " ---> " + product.CategoryName );
        //    }
        //}
        //else
        //{
        //    Console.WriteLine(result.Message);
        //}

        //ProductManager product = new ProductManager(new EfProductDal());
        //var result = product.GetById(1);
        //Console.WriteLine(result.Data.ProductName);




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
        foreach (var product in productManager.GetByUnitPrice(50, 100).Data)
        {
            Console.WriteLine(product.ProductName);
        }
    }
}