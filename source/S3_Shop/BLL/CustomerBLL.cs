using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Common;
using DAL.DAL;
using DAL.EF;
using Model;
using AutoMapper;

namespace BLL
{
    public class CustomerBLL
    {
        CustomerDAL customDal = new CustomerDAL();
        #region Insert, Update, Delete
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
        public bool InsertCustomer(CustomerModel cusInsert)
        {
            EntityMapper<Model.CustomerModel, CUSTOMER> mapObj = new EntityMapper<Model.CustomerModel,CUSTOMER>();
            CUSTOMER customObj  = mapObj.Translate(cusInsert);
            return customDal.InsertCustomer(customObj);
        }
        public bool UpdateCustomer(CustomerModel cusUpdate)
        {
            //EntityMapper<CustomerModel, CUSTOMER> mapObj = new EntityMapper<CustomerModel, CUSTOMER>();
            //CUSTOMER cusObj = new CUSTOMER();
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Product, Product>());
            //var mapper = new Mapper(config);
            //productObj = mapper.Map<Product>(product);
            //var status = DAL.UpdateProduct(productObj);
            //return status;
            EntityMapper<Model.CustomerModel, CUSTOMER> mapObj = new EntityMapper<Model.CustomerModel, CUSTOMER>();
            CUSTOMER customObj = mapObj.Translate(cusUpdate);
            return customDal.UpdateCustomer(customObj);
        }
        public bool DeleteCustomer(int id)
        {
            return customDal.DeleteCustomer(id);
        }
        #endregion
        #region Get by information
        public CustomerModel GetCustomerByID(int id)
        {
            EntityMapper<CUSTOMER, CustomerModel> mapObj = new EntityMapper<CUSTOMER, CustomerModel>();
            CUSTOMER cus = new CustomerDAL().GetCustomerByID(id);
            CustomerModel result = mapObj.Translate(cus);
            return result;
        }
        public CustomerModel GetCustomerByUsername(string user)
        {
            EntityMapper<CUSTOMER, CustomerModel> mapObj = new EntityMapper<CUSTOMER, CustomerModel>();
            CUSTOMER custom = customDal.GetCustomerByUsername(user);
            CustomerModel result = mapObj.Translate(custom);
            return result;
        }
        public CustomerModel GetCustomerByEmail(string mail)
        {
            EntityMapper<CUSTOMER, CustomerModel> mapObj = new EntityMapper<CUSTOMER, CustomerModel>();
            CUSTOMER custom = customDal.GetCustomerByEmail(mail);
            CustomerModel result = mapObj.Translate(custom);
            return result;
        }
        #endregion
        public int LoginCustomer(string user, string pass)
        {
            //0: tài khoản ko tồn tại
            //1: Thành công
            return customDal.GetLoginResultByUsernamePassword(user, pass);
        }
        public bool UpdatePasswordCustomer(int id, string pass)
        {
            var custom = GetCustomerByID(id);
            return (custom != null) ? customDal.ChangePasswordCustomer(id+"", pass) : false;
        }

    }
}
