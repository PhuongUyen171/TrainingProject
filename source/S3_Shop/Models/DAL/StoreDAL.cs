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
        private S3ShopDbContext db;

        public StoreDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }

        #region CRUD
        public bool CreateStore(STORE s)
        {
            try
            {
                db.STOREs.Add(s);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public bool UpdateStore(STORE s)
        {
            try
            {
                var itemUpdate = db.STOREs.Find(s.StoreID);
                itemUpdate.Phone = s.Phone;
                itemUpdate.Location = s.Location;
                itemUpdate.Images = s.Images;
                itemUpdate.City = s.City;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public bool DeleteStore(STORE s)
        {
            try
            {
                var itemDelete = db.STOREs.Find(s.StoreID);
                db.STOREs.Remove(itemDelete);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<STORE> GetAllStories()
        {
            return db.STOREs.Select(t => t).ToList();
        }
        public bool CheckStoreExist(int id)
        {
            return db.STOREs.Any(t=>t.StoreID==id);
        }

        #endregion
        public STORE GetStoryByID(int id)
        {
            return db.STOREs.Where(t=>t.StoreID==id).FirstOrDefault();
        }
        public List<STORE> GetStoriesByLocation(string local)
        {
            return db.STOREs.Where(t => t.Location == local).ToList();
        }
    }
}
