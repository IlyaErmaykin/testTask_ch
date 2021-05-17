using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Services.Implimentation
{
    public class RepairService : IRepairService
    {
        private IBaseRepository<StoreModel> Store { get; set; }
        private IBaseRepository<ProductModel> Product { get; set; }
        private IBaseRepository<StoreBalanceModel> StoreBalance { get; set; }

        public void Work()
        {
            var rand = new Random();
            var carId = 999999;
            var vendoreCode = 999999;

            Store.Create(new StoreModel
            {
                Id = Convert.ToInt32(carId),
                Name = String.Format($"Name{rand.Next()}"),
                Storekeeper = String.Format($"{rand.Next()}")
            });

            Product.Create(new ProductModel
            {
                VandoreCode = vendoreCode,
                Name = String.Format($"Name{rand.Next()}"),
                Unit = String.Format($"Unit{rand.Next()}"),
                Price = rand.NextDouble()
            });

            var store = Store.Get(carId);
            var vCode = Product.Get(vendoreCode);

            StoreBalance.Create(new StoreBalanceModel
            {
                StoreId = store.Id,
                VendoreCode = vCode.Id,
                Count = 999999,
                Date = DateTime.Now
            }); ;
        }
    }
}
