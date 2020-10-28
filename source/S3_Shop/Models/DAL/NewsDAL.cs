using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class NewsDAL
    {
        private S3ShopDbContext db;

        public NewsDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }

        #region CRUD
        public bool CreateNews(NEWS n)
        {
            try
            {
                db.NEWS.Add(n);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateNews(NEWS n)
        {
            try
            {
                var itemUpdate = db.NEWS.Find(n.NewsID);
                itemUpdate.PublishDate = n.PublishDate;
                itemUpdate.Title = n.Title;
                itemUpdate.Images = n.Images;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteNews(NEWS n)
        {
            try
            {
                var itemDelete = db.NEWS.Find(n.NewsID);
                db.NEWS.Remove(itemDelete);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<NEWS> GetAllNews()
        {
            return db.NEWS.Select(t => t).ToList();
        }
        public bool CheckNewsExist(int id)
        {
            return db.NEWS.Any(t => t.NewsID == id);
        }
        #endregion
        public NEWS GetNewsByID(int id)
        {
            return db.NEWS.Where(t => t.NewsID == id).FirstOrDefault();
        }
    }
}
