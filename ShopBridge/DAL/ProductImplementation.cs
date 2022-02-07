using ShopBridge.Models;
using System.Diagnostics.CodeAnalysis;

namespace ShopBridge.DAL
{
    [ExcludeFromCodeCoverage]
    public class ProductImplementation :IProductImplementation
    { 
        private readonly ProductDbContext Context;
        public ProductImplementation (ProductDbContext cntx)
        {
            Context = cntx;
        }

        public async Task<bool> AddProduct(Product product)
        {
            try
            {
                Task addProduct = Task.Run(async () =>
                {
                    Context.Products.Add(product);
                    Context.SaveChanges();
                });
                await Task.WhenAll(addProduct);
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Product>> ShowAllProducts()
        {
            var result = new List<Product>();
            Task ShowProducts = Task.Run(async () =>
            {
                 result = Context.Products.ToList();
            });
            await Task.WhenAll(ShowProducts);
            return result;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = new Product();
            try
            {
                Task getProduct = Task.Run(async() =>
                {
                    product =  Context.Products.FirstOrDefault(x => x.Id == id);
                });
                await Task.WhenAll(getProduct);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return product;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            Task deleteProduct = Task.Run(async () =>
            {
                Context.Products.Remove(product);
                Context.SaveChanges();
            });
            await Task.WhenAll(deleteProduct);
            
            return true;
        }


        //public void UpdateStockById(int id, int quantity)
        //{
        //    var p = GetProductById(id);            
        //}

        public async Task<bool> UpdateProduct(Product UpdatedProduct)
        {
            try
            {
                Task updateProduct = Task.Run(async () =>
                {
                    Context.Products.Update(UpdatedProduct);
                    Context.SaveChanges();
                });
                await Task.WhenAll(updateProduct);
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
