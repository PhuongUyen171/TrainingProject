using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.DAL
{
    public static class ProductDAL
    {
        static S3ShopDbContext db;
        static ProductDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }
        #region CRUD
        public static List<PRODUCT> GetAllProducts()
        {
            return db.PRODUCTs.ToList();
        }
        public static bool InsertProduct(PRODUCT product)
        {
            try
            {
                db.PRODUCTs.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool UpdateProduct(PRODUCT product)
        {
            try
            {
                var itemUpdate = GetProductByID(product.ProductID);
                if (itemUpdate != null)
                {
                    itemUpdate.ProductName = product.ProductName;
                    itemUpdate.CategoryID = product.CategoryID;
                    itemUpdate.Images = product.Images;
                    itemUpdate.Price = product.Price;
                    itemUpdate.Quantity = product.Quantity;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool DeleteProduct(int id)
        {
            try
            {
                var itemDelete = GetProductByID(id);
                if (itemDelete != null)
                {
                    db.PRODUCTs.Remove(itemDelete);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static PRODUCT GetProductByID(int id)
        {
            return db.PRODUCTs.Where(t => t.ProductID == id).FirstOrDefault();
        }
        #endregion
    }
}
