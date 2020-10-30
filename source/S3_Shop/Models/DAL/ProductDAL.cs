using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class ProductDAL
    {
        private S3ShopDbContext db;
        public ProductDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }

        #region CRUD
        public bool CreateProduct(PRODUCT p)
        {
            try
            {
                db.PRODUCTs.Add(p);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteProduct(int id)
        {
            try
            {
                var itemDelete = GetProductByID(id);
                db.PRODUCTs.Remove(itemDelete);
                db.SaveChanges();
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateProduct(PRODUCT p)
        {
            try
            {
                var itemUpdate = GetProductByID(p.ProductID);
                itemUpdate.ProductName = p.ProductName;
                itemUpdate.Quantity = p.Quantity;
                itemUpdate.Statu = p.Statu;
                itemUpdate.Price = p.Price;
                itemUpdate.Images = p.Images;
                itemUpdate.CategoryID = p.CategoryID;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<PRODUCT> GetAllProduct()
        {
            return db.PRODUCTs.Select(t => t).ToList();
        }
        #endregion

        public bool CheckProductExist(int id)
        {
            return db.PRODUCTs.Any(t => t.ProductID == id);
        }
        public PRODUCT GetProductByID(int id)
        {
            return db.PRODUCTs.FirstOrDefault(t => t.ProductID == id);
        }
        public List<PRODUCT> GetProductByCategory(int id)
        {
            return db.PRODUCTs.Where(t => t.CategoryID == id).ToList();
        }
    }
}
