using Moq;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    class RepairServiceTests
    {
        [Fact]
        public void WorkSuccessTest()
        {
            var serviceMock = new Mock<IRepairService>();
            var mockCars = new Mock<IBaseRepository<StoreModel>>();
            var mockWorkers = new Mock<IBaseRepository<StoreBalanceModel>>();
            var mockDocs = new Mock<IBaseRepository<ProductModel>>();
            var car = CreateCar(Guid.NewGuid());
            var worker = CreateWorker(Guid.NewGuid());
            var doc = CreateDoc(Guid.NewGuid(), worker.Id, car.Id);

            mockCars.Setup(x => x.Create(car)).Returns(car);
            mockDocs.Setup(x => x.Create(doc)).Returns(doc);
            mockWorkers.Setup(x => x.Create(worker)).Returns(worker);

            serviceMock.Object.Work();

            serviceMock.Verify(x => x.Work());
        }

        private StoreModel CreateCar(int carId)
        {
            return new StoreModel()
            {
                Id = carId,
                Name = "Engine Oil",
                Storekeeper = "Иванов ИИ"
            };
        }

        private StoreBalanceModel CreateWorker(Guid workerId)
        {
            return new StoreBalanceModel()
            {
                Id = workerId,
                Name = "worker",
                Position = "manager",
                Telephone = "89165555555"
            };
        }
        private Document CreateDoc(Guid docId, Guid workerId, Guid carId)
        {
            return new Document
            {
                Id = docId,
                CarId = carId,
                WorkerId = workerId
            };
        }
    }
}
