using ShopBridge.Models;

namespace ShopBridge.DAL
{
    public interface IProductImplementation
    {
        public Task<bool> AddProduct(Product product);
        Task<IEnumerable<Product>> ShowAllProducts();
        public Task<Product> GetProductById(int id);
        public Task<bool> DeleteProduct(Product product);
        public Task<bool> UpdateProduct(Product UpdatedProduct);

    }
}
