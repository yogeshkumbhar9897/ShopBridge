using ShopBridge.DAL;
using ShopBridge.Models;
using ShopBridge.Services.Interface;

namespace ShopBridge.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductImplementation _productImplementation;
        public ProductService(IProductImplementation productImplementation)
        {
            _productImplementation = productImplementation;
        }

        public async Task<Response> GetProduct(int id)
        {
            var response = new Response();
            try
            {
                var product = await _productImplementation.GetProductById(id);
                if (product == null)
                    throw new Exception(String.Format("Product is not available for id : {0}", id));
                response.Data = product;
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response> GetAllProduct()
        {
            var response = new Response();
            try
            {
                var products = await _productImplementation.ShowAllProducts();
                if (products == null)
                    throw new Exception(String.Format("Products are not available"));
                response.Data = products;
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.Data = null;
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response> InsertProduct(Product product)
        {
            var response = new Response();
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException("Sorry ...Can not add empty Product !!!");
                }
                 response.IsSuccess =  await _productImplementation.AddProduct(product);
                 response.Data = "Product Added Successfully";
            }
            catch(Exception ex)
            {
                response.Data = null;
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;

        }

        public async Task<Response> UpdateProduct(int id, Product UpdatedProduct)
        {
            var response = new Response();
            try
            {
                var p = await _productImplementation.GetProductById(id);
                if (p == null)
                {
                    throw new Exception("Product is not available");
                }
                p.PName = String.IsNullOrEmpty(UpdatedProduct?.PName) ? p.PName : UpdatedProduct.PName;
                p.PDescription = String.IsNullOrEmpty(UpdatedProduct?.PDescription) ? p.PDescription : UpdatedProduct.PDescription;
                p.PQuantity = String.IsNullOrEmpty(Convert.ToString(UpdatedProduct?.PQuantity)) ? p.PQuantity : UpdatedProduct.PQuantity;
                p.PPrice = String.IsNullOrEmpty(Convert.ToString(UpdatedProduct?.PPrice)) ? p.PPrice : UpdatedProduct.PPrice;
                response.IsSuccess = await _productImplementation.UpdateProduct(p);
                response.Data = "Product Updated Successfully";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<Response> DeleteProduct(int id)
        {
            var response = new Response();
            try
            {
                var product = await _productImplementation.GetProductById(id);
                if (product == null)
                {
                    throw new Exception(String.Format("Product id {0} is not available ", id));
                }
                else
                {
                    response.IsSuccess = await _productImplementation.DeleteProduct(product);
                    response.Data = "Product Deleted Successfully !!";
                }
            }
            catch (Exception ex)
            {

                response.Data = null;
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;

        }
    }
}
