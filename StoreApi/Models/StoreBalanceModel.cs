using StoreApi.Models.Base;
using System;

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
