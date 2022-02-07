using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Models;
using ShopBridge.Services.Interface;

namespace ShopBridge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController/Details/5
        [HttpGet("{id}")]
        public async Task<Response> GetProduct(int id)
        {
            return await _productService.GetProduct(id);
        }

        [HttpGet]
        public async Task<Response> GetProducts()
        {
            return await _productService.GetAllProduct();
        }

        // GET: ProductController/Create
        [HttpPost("Product")]
        public async Task<Response> InsertNewProduct(Product product)
        {
            var response = new Response();
            try
            {
                response =  await _productService.InsertProduct(product);
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }


        [HttpDelete("{id}")]
        public async Task<Response> Delete(int id)
        {
            return await _productService.DeleteProduct(id);
        }

        [HttpPut("{id}")]
        public async Task<Response> UpdateProduct(int id, Product product)
        {
            var response = new Response();
            try
            {
                response = await _productService.UpdateProduct(id, product);
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
