﻿using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class RoleDAL
    {
        private S3ShopDbContext db;

        public RoleDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }

        #region CRUD
        public bool CreateRole(ROLE r)
        {
            try
            {
                db.ROLES.Add(r);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool UpdateRole(ROLE r)
        {
            try
            {
                var itemUpdate = db.ROLES.Find(r.RoleID);
                itemUpdate.RoleName = r.RoleName;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteRole(ROLE r)
        {
            try
            {
                var itemDelete = db.ROLES.Find(r.RoleID);
                db.ROLES.Remove(itemDelete);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<ROLE> GetAllRoles()
        {
            return db.ROLES.Select(t => t).ToList();
        }
        public bool CheckRoleExist(int id)
        {
            return db.ROLES.Any(t => t.RoleID == id);
        }

        #endregion
        public ROLE GetRoleByID(int id)
        {
            return db.ROLES.Where(t => t.RoleID == id).FirstOrDefault();
        }
    }
}
