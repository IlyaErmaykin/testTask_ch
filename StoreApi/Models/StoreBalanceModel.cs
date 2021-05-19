using StoreApi.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Models
{
    public class StoreBalanceModel : BaseModel
    {
        public int Id { get; set; }
        public long VendoreCode { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
    }
}
