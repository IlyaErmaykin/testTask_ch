using Microsoft.AspNetCore.Mvc;
using StoreApi.Controllers.Base;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace StoreApi.Controllers
{
    [Route("api/Balance")]
    [ApiController]
    public class StoreBalanceController : BaseController
    {
        private IRepairService RepairService { get; set; }

        private IBaseRepository<StoreBalanceModel> StoreBalance { get; set; }

        public StoreBalanceController(IRepairService repairService, IBaseRepository<StoreBalanceModel> document)
        {
            RepairService = repairService;
            StoreBalance = document;
        }

        /// GET: api/Balance
        [HttpGet]
        public JsonResult Get()
        {
            List<StoreBalanceModel> result = null;
            var output = "";
            try
            {
                result = StoreBalance.GetAll();
                output = "Request success";
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
            return JsonOk(output, result);
        }

        // POST: api/Balance
        [HttpPost("{id}")]
        public JsonResult Post(int id, [FromBody] StoreBalanceModel inputData)
        {
            try
            {
                var storeBalance = StoreBalance.Get(id) ?? throw new ArgumentNullException("Product not found");
                StoreBalance.Update(id, inputData);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
            return JsonOk("Update success");
        }
    }
}
