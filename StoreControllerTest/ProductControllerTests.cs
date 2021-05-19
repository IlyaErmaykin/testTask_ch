using Microsoft.AspNetCore.Mvc;
using Moq;
using StoreApi.Controllers;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ProductControllerTests
    {
        [Fact]
        public static void GetDataMessage()
        {
            var mockProduct = new Mock<IBaseRepository<ProductModel>>();
            var mockService = new Mock<IRepairService>();
            var document = GetDoc();
            mockProduct.Setup(x => x.GetAll()).Returns(new List<ProductModel> { document });

            // Arrange
            ProductController controller = new ProductController(mockService.Object, mockProduct.Object);

            // Act
            JsonResult result = controller.Get() as JsonResult;

            // Assert
            Assert.Equal(new List<ProductModel> { document }, result?.Value);
        }

        [Fact]
        public void GetNotNull()
        {
            var mockProduct = new Mock<IBaseRepository<ProductModel>>();
            var mockService = new Mock<IRepairService>();
            mockProduct.Setup(x => x.Create(GetDoc())).Returns(GetDoc());

            // Arrange
            ProductController controller = new ProductController(mockService.Object, mockProduct.Object);
            // Act
            JsonResult result = controller.Get() as JsonResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void PostDataMessage()
        {
            var mockProduct = new Mock<IBaseRepository<ProductModel>>();
            var mockService = new Mock<IRepairService>();
            mockProduct.Setup(x => x.Create(GetDoc())).Returns(GetDoc());
            var document = GetDoc();

            // Arrange
            ProductController controller = new ProductController(mockService.Object, mockProduct.Object);

            // Act
            JsonResult result = controller.Post(document) as JsonResult;

            // Assert
            Assert.Equal("Work was successfully done", result?.Value);
        }

        [Fact]
        public void UpdateDataMessage()
        {
            var mockProduct = new Mock<IBaseRepository<ProductModel>>();
            var mockService = new Mock<IRepairService>();
            var document = GetDoc();

            mockProduct.Setup(x => x.Get(document.Id)).Returns(document);
            mockProduct.Setup(x => x.Update(document.Id, document)).Returns(document);

            // Arrange
            ProductController controller = new ProductController(mockService.Object, mockProduct.Object);

            // Act
            JsonResult result = controller.Post(document) as JsonResult;

            // Assert
            Assert.Equal($"Update successful {document.Id}", result?.Value);
        }

        [Fact]
        public void DeleteDataMessage()
        {
            var mockProduct = new Mock<IBaseRepository<ProductModel>>();
            var mockService = new Mock<IRepairService>();
            var doc = GetDoc();

            mockProduct.Setup(x => x.Get(doc.Id)).Returns(doc);
            mockProduct.Setup(x => x.Delete(doc.Id));

            // Arrange
            ProductController controller = new ProductController(mockService.Object, mockProduct.Object);

            // Act
            JsonResult result = controller.Delete(doc.Id) as JsonResult;

            // Assert
            Assert.Equal("Delete successful", result?.Value);
        }

        public static ProductModel GetDoc()
        {
            var mockStore = new Mock<IBaseRepository<StoreModel>>();
            var mockStoreBalance = new Mock<IBaseRepository<StoreBalanceModel>>();

            var storeId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            mockStore.Setup(x => x.Create(new StoreModel()
            {
                Id = Convert.ToInt32(storeId),
                Name = "TEST",
                Storekeeper = "TEST"
            }));

            mockStoreBalance.Setup(x => x.Create(new StoreBalanceModel()
            {
                Id = Convert.ToInt32(productId),
                VendoreCode = 99999999,
                Count = 1000,
                Date = DateTime.Now
            }));

            return new ProductModel
            {
                Id = 1,
                VendoreCode = 999999,
                Unit = "TEST",
                Price = 0.0
                
            };
        }
    }
}
