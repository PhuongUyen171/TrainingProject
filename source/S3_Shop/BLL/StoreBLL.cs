using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DAL;
using Models.EF;

namespace BLL
{
    public class StoreBLL
    {
        private StoreDAL s;
        public StoreBLL() 
        {
            s = new StoreDAL();
        }
        public List<STORE> GetAllStories()
        {
            return s.GetAllStories();
        }
        public STORE GetDetailStory(int id)
        {
            return s.GetStoryByID(id);
        }
        public List<STORE> GetStoreByLocation(string local)
        {
            return s.GetStoriesByLocation(local);
        }

        #region Insert, update, delete
        public bool InsertStore(STORE store)
        {
            return s.CreateStore(store);
        }
        public bool UpdateStore(STORE store)
        {
            return s.UpdateStore(store);
        }
        public bool DeleteStore(int id)
        {
            return s.DeleteStore(id);
        }
        #endregion
    }
}
