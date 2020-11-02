using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public static class RoleDAL
    {
        static S3ShopDbContext db;
        static RoleDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }

        #region CRUD
        public static bool InsertRole(ROLE role)
        {
            try
            {
                db.ROLES.Add(role);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool DeleteRole(int id)
        {
            try
            {
                var itemDelete = GetRoleByID(id);
                if (itemDelete != null)
                {
                    db.ROLES.Remove(itemDelete);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool UpdateRole(ROLE role)
        {
            try
            {
                var itemUpdate = GetRoleByID(role.RoleID);
                if (itemUpdate != null)
                {
                    itemUpdate.RoleName = role.RoleName;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static List<ROLE> GetAllRoles()
        {
            return db.ROLES.ToList();
        }
        #endregion

        public static ROLE GetRoleByID(int id)
        {
            return db.ROLES.Where(t => t.RoleID == id).FirstOrDefault();
        }
    }
}

