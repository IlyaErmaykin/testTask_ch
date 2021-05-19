using StoreApi.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Models
{
    public class StoreModel : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Storekeeper { get; set; }
    }
}
