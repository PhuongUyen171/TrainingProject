using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.DAL
{
    public static class BillDAL
    {
        static S3ShopDbContext db;
        static BillDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }
        #region CRUD
        public static List<BILL> GetAllBills()
        {
            return db.BILLs.ToList();
        }
        public static bool InsertBill(BILL bill)
        {
            try
            {
                db.BILLs.Add(bill);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool UpdateBill(BILL bill)
        {
            try
            {
                var itemUpdate = GetBillByID(bill.BillID);
                if (itemUpdate != null)
                {
                    itemUpdate.CustomID = bill.CustomID;
                    itemUpdate.DeliveryDate = bill.DeliveryDate;
                    itemUpdate.EmployID = bill.EmployID;
                    itemUpdate.PublishDate = bill.PublishDate;
                    itemUpdate.ToTalPrice = bill.ToTalPrice;
                    itemUpdate.Sale = bill.Sale;
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
        public static BILL GetBillByID(int id)
        {
            return db.BILLs.FirstOrDefault(t => t.BillID == id);
        }

        public static List<BILLINFO> GetBillInfoByBillID(int id)
        {
            return db.BILLINFOes.Where(t => t.BillID == id).ToList();
        }
    }
}
