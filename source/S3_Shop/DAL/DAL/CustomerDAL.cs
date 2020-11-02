using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.DAL
{
    public static class CustomerDAL
    {
        static S3ShopDbContext db;
        static CustomerDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }
        #region CRUD
        public static List<CUSTOMER> GetAllCustomers()
        {
            return db.CUSTOMERs.ToList();
        }
        public static bool InsertCustomer(CUSTOMER custom)
        {
            try
            {
                db.CUSTOMERs.Add(custom);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool DeleteCustomer(int id)
        {
            try
            {
                var itemDelete = GetCustomerByID(id);
                if (itemDelete != null)
                {
                    db.CUSTOMERs.Remove(itemDelete);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool UpdateCustomer(CUSTOMER custom)
        {
            try
            {
                var itemUpdate = GetCustomerByID(custom.CustomID);
                if (itemUpdate != null)
                {
                    itemUpdate.CustomName = custom.CustomName;
                    itemUpdate.Email = custom.Email;
                    itemUpdate.Location = custom.Location;
                    itemUpdate.Phone = custom.Phone;
                    itemUpdate.Pass = custom.Pass;
                    itemUpdate.MemID = custom.MemID;
                    itemUpdate.Statu = custom.Statu;
                    itemUpdate.TotalPrice = custom.TotalPrice;
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
        public static CUSTOMER GetCustomerByID(int id)
        {
            return db.CUSTOMERs.Where(t => t.CustomID == id).FirstOrDefault();
        }
    }
}
