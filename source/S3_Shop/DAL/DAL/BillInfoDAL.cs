using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.DAL
{
    public static class BillInfoDAL
    {
        static S3ShopDbContext db;
        static BillInfoDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }
        #region CRUD
        public static bool InsertBillInfo(BILLINFO billInfo)
        {
            try
            {
                db.BILLINFOes.Add(billInfo);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool DeleteBillInfo(int billID,int productId)
        {
            try
            {
                var itemDelete = GetBillInfoByBillInforID(billID, productId);
                if (itemDelete != null)
                {
                    db.BILLINFOes.Remove(itemDelete);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool UpdateBillInfo(BILLINFO billInfo)
        {
            try
            {
                var itemUpdate = GetBillInfoByBillInforID(billInfo.BillID, billInfo.ProductID);
                if (itemUpdate != null)
                {
                    itemUpdate.Quantity = billInfo.Quantity;
                    itemUpdate.Price = billInfo.Price;
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
        public static BILLINFO GetBillInfoByBillInforID(int billID, int productID)
        {
            return db.BILLINFOes.FirstOrDefault(t => t.BillID == billID & t.ProductID == productID);
        }
        
    }
}
