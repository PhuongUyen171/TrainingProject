using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL
{
    public class BillInforDAL
    {
        private S3ShopDbContext db = new S3ShopDbContext();
        public BillInforDAL()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        #region CRUD
        public bool InsertBillInfor(BILLINFO billInfo)
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
        public bool DeleteBillInfor(int billID, int productId)
        {
            try
            {
                var itemDelete = GetBillInforByBillInforID(billID, productId);
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
        public bool UpdateBillInfor(BILLINFO billInfo)
        {
            try
            {
                var itemUpdate = GetBillInforByBillInforID(billInfo.BillID, billInfo.ProductID);
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
        public List<BILLINFO> GetAllBillInforByID(int id)
        {
            return db.BILLINFOes.Where(t => t.BillID == id).ToList();
        }
        #endregion
        public BILLINFO GetBillInforByBillInforID(int billID, int productID)
        {
            return db.BILLINFOes.FirstOrDefault(t => t.BillID == billID & t.ProductID == productID);
        }

    }
}
