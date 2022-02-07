using ShopBridge.Models;

namespace ShopBridge.Services.Interface
{
    public interface IProductService
    {
        public Task<Response> GetProduct(int id);

        public Task<Response> GetAllProduct();

        public Task<Response> InsertProduct(Product product);

        public Task<Response> UpdateProduct(int id, Product UpdatedProduct);
        
        public Task<Response> DeleteProduct(int id);
    }
}
