using System;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Models;
using StoreApi.Repositories.Interfaces;
using StoreApi.Services.Interfaces;
using StoreApi.Controllers.Base;
using System.Collections.Generic;

namespace StoreApi.Controllers
{
    [Route("api/ProductItems")]
    [ApiController]
    public class ProductController : BaseController
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
            List<ProductModel> result = null;
            var output = "";
            try
            {
                result = Products.GetAll();
                output = "Request seccess";
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
            return JsonOk(output, result);
        }

        // GET: api/ProductItems/5
        [HttpGet("{id}")]
        public JsonResult GetStoreItems(int id)
        {
            ProductModel result = null;
            var output = "";
            try
            {
                result = Products.Get(id);
                output = "Request success";
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
            return JsonOk(output, result);
        }

        // POST: api/ProductItems
        [HttpPost]
        public JsonResult Post([FromBody] ProductModel inputData)
        {
            ProductModel result = null;
            var output = "";
            try
            {
                result = Products.Create(inputData);
                output = "Product Create";
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

            return JsonOk(output, result);
        }

        // DELETE: api/ProductItems/{id}
        [HttpDelete("{id}")]
        public JsonResult Delete(long id)
        {
            try
            {
                var product = Products.Get(id) ?? throw new ArgumentException("Product not found");
                Products.Delete(product.Id);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
            return JsonOk("Delete success");
        }
    }
}
