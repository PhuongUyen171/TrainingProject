using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.DAL
{
    public static class GroupAdminDAL
    {
        static S3ShopDbContext db;
        static GroupAdminDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }
        #region CRUD
        public static List<GROUPADMIN> GetAllGroupAdmin(string id)
        {
            return db.GROUPADMINs.ToList();
        }
        public static bool InsertGroupAdmin(GROUPADMIN group) {
            try
            {
                db.GROUPADMINs.Add(group);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool DeleteGroupAdmin(string id)
        {
            try
            {
                var itemDelete = GetGroupAdminByID(id);
                if (itemDelete != null)
                {
                    db.GROUPADMINs.Remove(itemDelete);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool UpdateGroupAdmin(GROUPADMIN group)
        {
            try
            {
                var itemUpdate = GetGroupAdminByID(group.GroupID);
                if (itemUpdate != null)
                {
                    itemUpdate.GroupName = group.GroupName;
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
        public static GROUPADMIN GetGroupAdminByID(string id)
        {
            return db.GROUPADMINs.FirstOrDefault(t => t.GroupID == id);
        }
        public static int GetEmployeeByGroupID(string id)
        {
            return db.EMPLOYEEs.Count(t => t.GroupID == id);
        }
    }
}
