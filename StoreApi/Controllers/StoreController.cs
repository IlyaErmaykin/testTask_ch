using System;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Services.Interfaces;
using StoreApi.Controllers.Base;
using System.Collections.Generic;

namespace StoreApi.Controllers
{
    [Route("api/StoreItems")]
    [ApiController]
    public class StoreController : BaseController
    {
        private IRepairService RepairService { get; set; }
        private IBaseRepository<StoreModel> Stores { get; set; }

        public StoreController(IRepairService repairService, IBaseRepository<StoreModel> document)
        {
            RepairService = repairService;
            Stores = document;
        }

        //// GET: api/StoreItems
        [HttpGet]
        public JsonResult Get()
        {
            List<StoreModel> result = null;
            var output = "";
            try
            {
                result = Stores.GetAll();
                output = "Request success";
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
            return JsonOk(output, result);
        }

        // GET: api/StoreItems/5
        [HttpGet("{id}")]
        public JsonResult GetStoreItems(int id)
        {
            StoreModel result = null;
            var output = "";
            try
            {
                result = Stores.Get(id);
                output = "Request success";
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
            return JsonOk(output, result);
        }

        // POST: api/StoreItems
        [HttpPost]
        public JsonResult Post([FromBody] StoreModel inputData)
        {
            StoreModel result = null;
            var output = "";
            try
            {
                result = Stores.Create(inputData);
                output = "Store Create";
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
            return JsonOk(output, result);
        }

        // DELETE: api/StoreItems
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                var store = Stores.Get(id) ?? throw new ArgumentNullException("Store not found");
                Stores.Delete(store.Id);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
            return JsonOk("Delete successful");
        }
    }
}
