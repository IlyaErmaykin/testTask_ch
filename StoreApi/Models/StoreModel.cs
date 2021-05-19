using StoreApi.Models.Base;

namespace StoreApi.Models
{
    public class StoreModel : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Storekeeper { get; set; }
    }
}
