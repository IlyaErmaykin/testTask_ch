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
    public class StoreBalanceControllTestd
    {
        [Fact]
        public static void GetDataMessage()
        {
            var mockStoreBalance = new Mock<IBaseRepository<StoreBalanceModel>>();
            var mockService = new Mock<IRepairService>();
            var document = GetDoc();
            mockStoreBalance.Setup(x => x.GetAll()).Returns(new List<StoreBalanceModel> { document });

            // Arrange
            StoreBalanceController controller = new StoreBalanceController(mockService.Object, mockStoreBalance.Object);

            // Act
            JsonResult result = controller.Get() as JsonResult;

            // Assert
            Assert.Equal(new List<StoreBalanceModel> { document }, result?.Value);
        }

        [Fact]
        public void GetNotNull()
        {
            var mockStoreBalance = new Mock<IBaseRepository<StoreBalanceModel>>();
            var mockService = new Mock<IRepairService>();
            mockStoreBalance.Setup(x => x.Create(GetDoc())).Returns(GetDoc());

            // Arrange
            StoreBalanceController controller = new StoreBalanceController(mockService.Object, mockStoreBalance.Object);
            // Act
            JsonResult result = controller.Get() as JsonResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateDataMessage()
        {
            var mockStoreBalance = new Mock<IBaseRepository<StoreBalanceModel>>();
            var mockService = new Mock<IRepairService>();
            var document = GetDoc();

            mockStoreBalance.Setup(x => x.Get(document.Id)).Returns(document);
            mockStoreBalance.Setup(x => x.Update(document.Id, document)).Returns(document);

            // Arrange
            StoreBalanceController controller = new StoreBalanceController(mockService.Object, mockStoreBalance.Object);

            // Act
            JsonResult result = controller.Post(document.Id, document) as JsonResult;

            // Assert
            Assert.Equal($"Update successful {document.Id}", result?.Value);
        }

        public static StoreBalanceModel GetDoc()
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

            return new StoreBalanceModel
            {
                Id = Convert.ToInt32(productId),
                VendoreCode = 99999999,
                Count = 1000,
                Date = DateTime.Now

            };
        }
    }
}
