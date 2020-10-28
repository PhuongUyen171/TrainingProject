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
        StoreDAL s = new StoreDAL();
        public StoreBLL() 
        {
            s = new StoreDAL();
        }
        public IEnumerable<STORE> GetAllStories()
        {
            return s.GetAllStories();
        }
        public STORE GetDetailStory(int id)
        {
            return s.GetStoryByID(id);
        }
        public IEnumerable<STORE> GetStoreByLocation(string local)
        {
            return s.GetStoriesByLocation(local);
        }
    }
}
