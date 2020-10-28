using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAL
{
    public class StoreDAL
    {
        S3ShopDbContext db = new S3ShopDbContext();

        public StoreDAL()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        public IEnumerable<STORE> GetAllStories()
        {
            return db.STOREs.Select(t => t);
        }

        public STORE GetStoryByID(int id)
        {
            return db.STOREs.Where(t=>t.StoreID==id).FirstOrDefault();
        }

        public IEnumerable<STORE> GetStoriesByLocation(string local)
        {
            return db.STOREs.Where(t => t.Location == local);
        }
    }
}
