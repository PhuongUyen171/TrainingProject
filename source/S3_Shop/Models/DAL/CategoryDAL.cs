﻿using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class CategoryDAL
    {
        private S3ShopDbContext db;
        public CategoryDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }

        #region CRUD
        public bool CreateCategory(CATEGORY c)
        {
            try
            {
                db.CATEGORies.Add(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeteleCategory(int id)
        {
            try
            {
                var itemDelete = GetCategoryByID(id);
                db.CATEGORies.Remove(itemDelete);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateCategory(CATEGORY c)
        {
            try
            {
                var itemUpdate = GetCategoryByID(c.CateID);
                itemUpdate.CateName = c.CateName;
                itemUpdate.Images = c.Images;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<CATEGORY> GetAllCategories()
        {
            return db.CATEGORies.Select(t => t).ToList();
        }
        #endregion

        public CATEGORY GetCategoryByID(int id)
        {
            return db.CATEGORies.Where(t => t.CateID == id).FirstOrDefault();
        }
        public bool CheckCategoryExist(int id)
        {
            return db.CATEGORies.Any(t => t.CateID == id);
        }
    }
}
