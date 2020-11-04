using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.DAL
{
    public class EmployeeDAL
    {
        private S3ShopDbContext db = new S3ShopDbContext();
        public EmployeeDAL()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        #region CRUD
        public bool InsertEmployee(EMPLOYEE employee)
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
        public bool DeleteEmployee(int id)
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
        public bool UpdateEmployee(EMPLOYEE employee)
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
        public List<EMPLOYEE> GetAllEmployees()
        {
            return db.EMPLOYEEs.ToList();
        }
        #endregion
        public EMPLOYEE GetEmployeeByID(int id)
        {
            return db.EMPLOYEEs.Where(t => t.EmployID == id).FirstOrDefault();
        }
        public bool CheckEmployeeExist(string adminName,string pass)
        {
            return db.EMPLOYEEs.Any(t => t.EmployName==adminName & t.Pass == pass);
        }
    }
}
