using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.DAL
{
    public static class EmployeeDAL
    {
        static S3ShopDbContext db;
        static EmployeeDAL()
        {
            db = new S3ShopDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }
        #region CRUD
        public static bool InsertEmployee(EMPLOYEE employee)
        {
            try
            {
                db.EMPLOYEEs.Add(employee);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool DeleteEmployee(int id)
        {
            try
            {
                var itemDelete = GetEmployeeByID(id);
                if (itemDelete != null)
                {
                    db.EMPLOYEEs.Remove(itemDelete);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool UpdateEmployee(EMPLOYEE employee)
        {
            try
            {
                var itemUpdate = GetEmployeeByID(employee.EmployID);
                if (itemUpdate != null)
                {
                    itemUpdate.EmployName = employee.EmployName;
                    itemUpdate.FirstName = employee.FirstName;
                    itemUpdate.LastName = employee.LastName;
                    itemUpdate.Pass = employee.Pass;
                    itemUpdate.Statu = employee.Statu;
                    itemUpdate.GroupID = employee.GroupID;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static List<EMPLOYEE> GetAllEmployees()
        {
            return db.EMPLOYEEs.ToList();
        }
        #endregion
        public static EMPLOYEE GetEmployeeByID(int id)
        {
            return db.EMPLOYEEs.Where(t => t.EmployID == id).FirstOrDefault();
        }
    }
}
