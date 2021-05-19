using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Models.Base;

namespace StoreApi.Repositories.Interfaces
{
    public interface IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        public List<TDbModel> GetAll();
        public TDbModel Get(int id);
        public TDbModel Get(long id);
        public TDbModel Create(TDbModel model);
        public TDbModel Update(int id, TDbModel model);
        public TDbModel Update(long id, TDbModel model);
        public void Delete(int id);
        public void Delete(long id);
    }
}
