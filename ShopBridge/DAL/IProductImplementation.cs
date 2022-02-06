using ShopBridge.Models;

namespace ShopBridge.DAL
{
    public interface IProductImplementation
    {
        public Task<bool> AddProduct(Product product);
        public Task<Product> GetProductById(int id);
        public Task<bool> DeleteProduct(Product product);
        public Task<bool> UpdateProduct(Product UpdatedProduct);

    }
}
