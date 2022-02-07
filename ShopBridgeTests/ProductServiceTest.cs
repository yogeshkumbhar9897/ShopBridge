using Moq;
using NUnit.Framework;
using ShopBridge.DAL;
using ShopBridge.Models;
using ShopBridge.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeTests
{
    public class ProductServiceTest
    {
        private Mock<IProductImplementation> _productImplementation;
        private ProductService productService;
        private ProductService productServiceException;

        [SetUp]
        public void Setup()
        {
            _productImplementation = new Mock<IProductImplementation>();
            productService = new ProductService(_productImplementation.Object);
            productServiceException = new ProductService(null);
        }

        [Test]
        public async Task GetProduct_Success()
        {
            //Arrange
            _productImplementation.Setup(x => x.GetProductById(It.IsAny<int>())).ReturnsAsync(new Product());


            //Act
            var result = await productService.GetProduct(new int());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public async Task GetProduct_Exception()
        {
            //Arrange
            _productImplementation.Setup(x => x.GetProductById(It.IsAny<int>())).Throws(new Exception());


            //Act
            var result = await productServiceException.GetProduct(new int());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
        }

        [Test]
        public async Task GetAllProducts_Success()
        {
            //Arrange
            _productImplementation.Setup(x => x.ShowAllProducts()).ReturnsAsync(new List<Product>());


            //Act
            var result = await productService.GetAllProduct();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public async Task GetAllProducts_Exception()
        {
            //Arrange
            _productImplementation.Setup(x => x.ShowAllProducts()).Throws(new Exception());


            //Act
            var result = await productServiceException.GetAllProduct();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
        }

        [Test]
        public async Task InsertProduct_Success()
        {
            //Arrange
            _productImplementation.Setup(x => x.AddProduct(It.IsAny<Product>())).ReturnsAsync(true);
            //Act
            var result = await productService.InsertProduct(new Product());

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.IsSuccess);
        }


        [Test]
        public async Task InsertProduct_Exception()
        {
            //Arrange
            _productImplementation.Setup(x => x.AddProduct(It.IsAny<Product>())).Throws(new Exception());
            //Act
            var result = await productServiceException.InsertProduct(new Product());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);

        }

        [Test]
        public async Task UpdateProduct_Success()
        {
            //Arrange
            _productImplementation.Setup(x => x.UpdateProduct(It.IsAny<Product>())).ReturnsAsync(true);
            _productImplementation.Setup(x => x.GetProductById(It.IsAny<int>())).ReturnsAsync(new Product());
            //Act
            var result = await productService.UpdateProduct(new int(), new Product());

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.IsSuccess);
        }


        [Test]
        public async Task UpdateProduct_Exception()
        {
            //Arrange
            _productImplementation.Setup(x => x.UpdateProduct(It.IsAny<Product>())).Throws(new Exception());
            //Act
            var result = await productServiceException.UpdateProduct(new int(), new Product());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);

        }

        [Test]
        public async Task UpdateProduct_NullProductException()
        {
            //Arrange
            _productImplementation.Setup(x => x.UpdateProduct(It.IsAny<Product>())).ReturnsAsync(true);
            //Act
            var result = await productService.UpdateProduct(new int(), new Product());

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(false, result.IsSuccess);
        }

        [Test]
        public async Task DeleteProduct_Success()
        {
            //Arrange
            _productImplementation.Setup(x => x.DeleteProduct(It.IsAny<Product>())).ReturnsAsync(true);
            _productImplementation.Setup(x => x.GetProductById(It.IsAny<int>())).ReturnsAsync(new Product());
            //Act
            var result = await productService.DeleteProduct(new int());

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.IsSuccess);
        }


        [Test]
        public async Task DeleteProduct_Exception()
        {
            //Arrange
            _productImplementation.Setup(x => x.DeleteProduct(It.IsAny<Product>())).Throws(new Exception());
            //Act
            var result = await productServiceException.DeleteProduct(new int());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);

        }

        [Test]
        public async Task DeleteProduct_NullProductException()
        {
            //Arrange
            _productImplementation.Setup(x => x.DeleteProduct(It.IsAny<Product>())).ReturnsAsync(true);
            //Act
            var result = await productService.DeleteProduct(new int());

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(false, result.IsSuccess);
        }
    }
}
