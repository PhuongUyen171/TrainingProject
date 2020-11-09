using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Common;
using DAL.DAL;
using DAL.EF;
using Model;

namespace BLL
{
    public class CustomerBLL
    {
        CustomerDAL customDal = new CustomerDAL();
        public List<CustomerModel> GetAllCustomers()
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
        public bool InsertCustomer(CustomerModel cusInsert)
        {
            EntityMapper<Model.CustomerModel, CUSTOMER> mapObj = new EntityMapper<Model.CustomerModel,CUSTOMER>();
            CUSTOMER customObj  = mapObj.Translate(cusInsert);
            return customDal.InsertCustomer(customObj);
        }
        public bool UpdateCustomer(CustomerModel cusUpdate)
        {
            EntityMapper<Model.CustomerModel, CUSTOMER> mapObj = new EntityMapper<Model.CustomerModel, CUSTOMER>();
            CUSTOMER customObj = mapObj.Translate(cusUpdate);
            return customDal.UpdateCustomer(customObj);
        }
        public bool DeleteCustomer(int id)
        {
            return customDal.DeleteCustomer(id);
        }
        public CustomerModel GetCustomerByID(int id)
        {
            EntityMapper<CUSTOMER, CustomerModel> mapObj = new EntityMapper<CUSTOMER, CustomerModel>();
            CUSTOMER cus = new CustomerDAL().GetCustomerByID(id);
            CustomerModel result = mapObj.Translate(cus);
            return result;
        }
    }
}
