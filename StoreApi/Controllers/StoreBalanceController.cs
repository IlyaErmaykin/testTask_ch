using Microsoft.AspNetCore.Mvc;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Services.Interfaces;

namespace StoreApi.Controllers
{
    [Route("api/Balance")]
    [ApiController]
    public class StoreBalanceController : ControllerBase
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
            return new JsonResult(StoreBalance.GetAll());
        }

        // POST: api/Balance
        [HttpPost("{id}")]
        public JsonResult Post(int id, [FromBody] StoreBalanceModel inputData)
        {
            //var result = 200;
            
            return new JsonResult(StoreBalance.Update(id, inputData));
            //return new JsonResult(result);
        }
    }
}
