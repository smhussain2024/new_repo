using ConsoleWebAPI.Models;

namespace ConsoleWebAPI.Repository
{
    public interface IProductRepository
    {
        int AddProduct(ProductModel product);
        List<ProductModel> GetProducts();

        string GetProductName();
    }
}