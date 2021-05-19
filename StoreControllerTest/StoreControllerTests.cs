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
    public class StoreControllerTests
    {
        [Fact]
        public static void GetDataMessage()
        {
            var mockStore = new Mock<IBaseRepository<StoreModel>>();
            var mockService = new Mock<IRepairService>();
            var document = GetDoc();
            mockStore.Setup(x => x.GetAll()).Returns(new List<StoreModel> { document });

            // Arrange
            StoreController controller = new StoreController(mockService.Object, mockStore.Object);

            // Act
            JsonResult result = controller.Get() as JsonResult;

            // Assert
            Assert.Equal(new List<StoreModel> { document }, result?.Value);
        }

        [Fact]
        public void GetNotNull()
        {
            var mockStore = new Mock<IBaseRepository<StoreModel>>();
            var mockService = new Mock<IRepairService>();
            mockStore.Setup(x => x.Create(GetDoc())).Returns(GetDoc());

            // Arrange
            StoreController controller = new StoreController(mockService.Object, mockStore.Object);
            // Act
            JsonResult result = controller.Get() as JsonResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void PostDataMessage()
        {
            var mockStore = new Mock<IBaseRepository<StoreModel>>();
            var mockService = new Mock<IRepairService>();
            mockStore.Setup(x => x.Create(GetDoc())).Returns(GetDoc());
            var document = GetDoc();

            // Arrange
            StoreController controller = new StoreController(mockService.Object, mockStore.Object);

            // Act
            JsonResult result = controller.Post(document) as JsonResult;

            // Assert
            Assert.Equal("Work was successfully done", result?.Value);
        }

        [Fact]
        public void UpdateDataMessage()
        {
            var mockStore = new Mock<IBaseRepository<StoreModel>>();
            var mockService = new Mock<IRepairService>();
            var document = GetDoc();

            mockStore.Setup(x => x.Get(document.Id)).Returns(document);
            mockStore.Setup(x => x.Update(document.Id, document)).Returns(document);

            // Arrange
            StoreController controller = new StoreController(mockService.Object, mockStore.Object);

            // Act
            JsonResult result = controller.Post(document) as JsonResult;

            // Assert
            Assert.Equal($"Update successful {document.Id}", result?.Value);
        }

        [Fact]
        public void DeleteDataMessage()
        {
            var mockStore = new Mock<IBaseRepository<StoreModel>>();
            var mockService = new Mock<IRepairService>();
            var doc = GetDoc();

            mockStore.Setup(x => x.Get(doc.Id)).Returns(doc);
            mockStore.Setup(x => x.Delete(doc.Id));

            // Arrange
            StoreController controller = new StoreController(mockService.Object, mockStore.Object);

            // Act
            JsonResult result = controller.Delete(doc.Id) as JsonResult;

            // Assert
            Assert.Equal("Delete successful", result?.Value);
        }

        public static StoreModel GetDoc()
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

            return new StoreModel
            {
                Id = 1,
                Name = "TEST",
                Storekeeper = "TEST"
            };
        }
    }
}

