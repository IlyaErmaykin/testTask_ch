using StoreApi.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Models
{
    public class ProductModel : BaseModel
    {
        public long Id { get; set; }
        public long VendoreCode { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
    }
}
