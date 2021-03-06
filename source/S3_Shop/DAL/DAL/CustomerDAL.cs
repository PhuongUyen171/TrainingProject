﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.DAL
{
    public class CustomerDAL
    {
        private S3ShopDbContext db = new S3ShopDbContext();
        public CustomerDAL()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        #region CRUD
        public List<CUSTOMER> GetAllCustomers()
        {
            return db.CUSTOMERs.ToList();
        }
        public bool InsertCustomer(CUSTOMER custom)
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
        public bool DeleteCustomer(int id)
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
        public bool UpdateCustomer(CUSTOMER custom)
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
        public CUSTOMER GetCustomerByID(int id)
        {
            return db.CUSTOMERs.Where(t => t.CustomID == id).FirstOrDefault();
        }
        public bool ChechCustomerExist(string username, string password)
        {
            return db.CUSTOMERs.Any(t => t.CustomName == username & t.Pass == password);
        }
        public bool ChangeStatusCustomer(string username)
        {
            try
            {
                var acc = db.CUSTOMERs.SingleOrDefault(x => x.CustomName==username);
                acc.Statu = !acc.Statu;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool LoginCustomer(string username, string pass)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
