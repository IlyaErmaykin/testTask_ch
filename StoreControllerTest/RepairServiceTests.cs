using Moq;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Services.Interfaces;
using System;
using Xunit;

namespace UnitTests
{
    public class RepairServiceTests
    {
        [Fact]
        public void WorkSuccessTest()
        {
            var serviceMock = new Mock<IRepairService>();
            var mockStore = new Mock<IBaseRepository<StoreModel>>();
            var mockProduct = new Mock<IBaseRepository<ProductModel>>();
            var mockStoreBalance = new Mock<IBaseRepository<StoreBalanceModel>>();
            var store = CreateStore(Guid.NewGuid());
            var product = CreateProduct(Guid.NewGuid());
            //var storeBalance = CreateStoreBalance(Guid.NewGuid(), product.Id, store.Id);

            mockStore.Setup(x => x.Create(store)).Returns(store);
            mockProduct.Setup(x => x.Create(product)).Returns(product);
            //mockStoreBalance.Setup(x => x.Create(storeBalance)).Returns(storeBalance);

            serviceMock.Object.Work();

            serviceMock.Verify(x => x.Work());
        }

        private StoreModel CreateStore(Guid carId)
        {
            return new StoreModel()
            {
                Id = Convert.ToInt32(carId),
                Name = "TEST_NAME",
                Storekeeper = "TEST_USER"
            };
        }

        private ProductModel CreateProduct(Guid prodictId)
        {
            return new ProductModel
            {
                Id = Convert.ToInt64(prodictId),
                VendoreCode = 1,
                Name = "TEST",
                Price = 0.0,
                Unit = "TEST"
            };
        }
        private StoreBalanceModel CreateStoreBalance(Guid docId, Guid workerId, Guid carId)
        {
            return new StoreBalanceModel()
            {
                Id = Convert.ToInt32(workerId),
                VendoreCode = 99999999,
                Count = 1,
                Date = DateTime.Now
            };
        }
    }
}
