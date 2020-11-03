using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Common;
using DAL.DAL;

namespace BLL
{
    public class CustomerBLL
    {
        CustomerDAL custom = new CustomerDAL();
        public List<Model.CustomerModel> GetAllCustomers()
        {
            EntityMapper<DAL.EF.CUSTOMER, Model.CustomerModel> mapObj = new EntityMapper<DAL.EF.CUSTOMER, Model.CustomerModel>();
            List<DAL.EF.CUSTOMER> customList = new CustomerDAL().GetAllCustomers();
            List<Model.CustomerModel> customers = new List<Model.CustomerModel>();
            foreach (var item in customList)
            {
                customers.Add(mapObj.Translate(item));
            }
            return (List<Model.CustomerModel>)customers;
        }
        public bool CheckCustomerExist(string user, string pass)
        {
            bool customer = new CustomerDAL().ChechCustomerExist(user, pass);
            return customer;
        }
    }
}
