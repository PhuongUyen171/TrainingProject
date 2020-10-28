using Models.EF;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAL
{
    public class CustomerDAL
    {
        private S3ShopDbContext db;
        public CustomerDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }

        #region CRUD
        public bool CreateCustomer(CUSTOMER c)
        {
            try
            {
                db.CUSTOMERs.Add(c);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateCustomer(CUSTOMER c)
        {
            try
            {
                var itemUpdate = db.CUSTOMERs.Where(t => t.CustomID == c.CustomID).FirstOrDefault();
                itemUpdate.CustomName = c.CustomName;
                itemUpdate.Email = c.Email;
                itemUpdate.Phone = c.Phone;
                itemUpdate.Statu = c.Statu;
                itemUpdate.Pass = c.Pass;
                itemUpdate.Location = c.Location;
                itemUpdate.TotalPrice = c.TotalPrice;
                itemUpdate.MemID = c.MemID;
                //MEMBERSHIP tự cập nhật là copper khi mới tạo: chưa xử lý
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteCustomer(int id)
        {
            try
            {
                var itemDelete = db.CUSTOMERs.Where(t => t.CustomID == id).FirstOrDefault();
                db.CUSTOMERs.Remove(itemDelete);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<CUSTOMER> GetAllCustomers()
        {
            return db.CUSTOMERs.Select(t => t).ToList();
        }
        #endregion

        public bool CheckCustomerExist(int id)
        {
            return db.CUSTOMERs.Any(t => t.CustomID == id);
        }

        public bool? CheckCustomerStatus(int id)
        {
            return CheckCustomerExist(id) ? db.CUSTOMERs.Find(id).Statu : false;
        }

        public CUSTOMER GetCustomerByID(int id)
        {
            return db.CUSTOMERs.Where(t => t.CustomID == id).FirstOrDefault();
        }
    }
}
