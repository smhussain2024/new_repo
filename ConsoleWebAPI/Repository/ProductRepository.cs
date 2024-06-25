using ConsoleWebAPI.Models;

namespace ConsoleWebAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private List<ProductModel> products = new List<ProductModel>();

        public ProductRepository() { }

        public int AddProduct(ProductModel product)
        {
            product.ProductID = products.Count + 1;
            products.Add(product);
            return product.ProductID;
        }

        public string GetProductName()
        {
            return "this is product name";
        }

        public List<ProductModel> GetProducts()
        {
            return products;
        }
    }
}
