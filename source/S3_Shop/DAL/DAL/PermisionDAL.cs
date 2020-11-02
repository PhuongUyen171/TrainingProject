using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
namespace DAL.DAL
{
    public static class PermisionDAL
    {
        static S3ShopDbContext db;
        static PermisionDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }
        #region CRUD
        public static bool InsertPermision(PERMISION per)
        {
            try
            {
                db.PERMISIONs.Add(per);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool UpdatePermision(PERMISION per)
        {
            try
            {
                var itemUpdate = GetPermisionByID(per.GroupID, per.RoleID);
                if (itemUpdate != null)
                {
                    itemUpdate.PerID = per.PerID;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        public static PERMISION GetPermisionByID(string groupId, int roleID)
        {
            return db.PERMISIONs.FirstOrDefault(t => t.GroupID == groupId & t.RoleID == roleID);
        }
    }
}
