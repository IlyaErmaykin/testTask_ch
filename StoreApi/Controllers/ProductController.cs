using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.Database;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Services.Interfaces;

namespace StoreApi.Controllers
{
    [Route("api/ProductItems")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IRepairService RepairService { get; set; }

        private IBaseRepository<ProductModel> Products { get; set; }

        public ProductController(IRepairService repairService, IBaseRepository<ProductModel> document)
        {
            RepairService = repairService;
            Products = document;
        }

        // GET: api/ProductItems
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Products.GetAll());
        }

        // GET: api/ProductItems/5
        [HttpGet("{id}")]
        public JsonResult GetStoreItems(int id)
        {
            return new JsonResult(Products.Get(id)); ;
        }

        // POST: api/ProductItems
        [HttpPost]
        public JsonResult Post([FromBody] ProductModel inputData)
        {
            return new JsonResult(Products.Create(inputData));
        }

        // DELETE: api/ProductItems/{id}
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            bool success = true;
            var document = Products.Get(id);

            try
            {
                if (document != null)
                {
                    Products.Delete(document.Id);
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

        // DELETE: api/ProductItems/{id}
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            bool success = true;
            var document = Products.Get(id);

            try
            {
                if (document != null)
                {
                    Products.Delete(document.Id);
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
