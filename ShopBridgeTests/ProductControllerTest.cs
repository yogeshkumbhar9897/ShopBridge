using Moq;
using NUnit.Framework;
using ShopBridge.Controllers;
using ShopBridge.DAL;
using ShopBridge.Models;
using ShopBridge.Services.Interface;
using System;
using System.Threading.Tasks;

namespace ShopBridgeTests
{
    public class ProductControllerTest
    {
        private Mock<IProductService> _productService;
        private ProductController productController;
        private ProductController productControllerException;

        [SetUp]
        public void Setup()
        {
            _productService = new Mock<IProductService>();
            productController = new ProductController(_productService.Object);
            productControllerException = new ProductController(null);
        }

        [Test]
        public async Task GetProduct_Success()
        {
            //Arrange
            _productService.Setup(x => x.GetProduct(It.IsAny<int>())).ReturnsAsync(new Response() { IsSuccess=true});


            //Act
            var result = await productController.GetProduct(new int());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public async Task IsProductDeletedSuccessfully()
        {
            //Arrange
            _productService.Setup(x=>x.DeleteProduct(It.IsAny<int>())).ReturnsAsync(new Response() { IsSuccess = true});

            //Act
            var result = await productController.Delete(new int());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public async Task IsProductInsertedSuccessfully()
        {
            //Arrange
            _productService.Setup(x => x.InsertProduct(It.IsAny<Product>())).ReturnsAsync(true);
            //Act
            var result =await productController.InsertNewProduct(new Product());

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.IsSuccess);
        }


        [Test]
        public async Task IsProductInsertedException()
        {
            //Arrange
            _productService.Setup(x => x.InsertProduct(It.IsAny<Product>())).Throws(new Exception());
            //Act
            var result =await productControllerException.InsertNewProduct(new Product());

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(false, result.IsSuccess);
        }

        [Test]
        public async Task IsProductUpdatedSuccessfully()
        {
            //Arrange
            _productService.Setup(x => x.UpdateProduct(It.IsAny<int>(),It.IsAny<Product>())).ReturnsAsync(new Response() { IsSuccess=true});
            //Act
            var result =await productController.UpdateProduct(new int(),new Product());

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.IsSuccess);
        }


        [Test]
        public async Task IsProductUpdatedException()
        {
            //Arrange
            _productService.Setup(x => x.UpdateProduct(It.IsAny<int>(), It.IsAny<Product>())).Throws(new Exception());
            //Act
            var result = await productControllerException.UpdateProduct(new int(), new Product());

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(false, result.IsSuccess);
        }
    }
}