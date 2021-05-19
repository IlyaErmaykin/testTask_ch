using System;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Services.Interfaces;

namespace StoreApi.Controllers
{
    [Route("api/StoreItems")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private IRepairService RepairService { get; set; }
        private IBaseRepository<StoreModel> Stores { get; set; }

        private IBaseRepository<ProductModel> Products { get; set; }

        public StoreController(IRepairService repairService, IBaseRepository<StoreModel> document)
        {
            RepairService = repairService;
            Stores = document;
        }

        //// GET: api/StoreItems
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Stores.GetAll());
        }

        // GET: api/StoreItems/5
        [HttpGet("{id}")]
        public JsonResult GetStoreItems(int id)
        {
            return new JsonResult(Stores.Get(id)); ;
        }

        // POST: api/StoreItems
        [HttpPost]
        public JsonResult Post([FromBody] StoreModel inputData)
        {
            return new JsonResult(Stores.Create(inputData));
        }

        // DELETE: api/StoreItems
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            bool success = true;
            var document = Stores.Get(id);

            try
            {
                if (document != null)
                {
                    Stores.Delete(document.Id);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");
        }
    }
}
