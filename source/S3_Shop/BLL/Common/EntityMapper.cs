using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Common
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public EntityMapper()
        {
            //Cateogory
            Mapper.CreateMap<Model.CategoryModel,DAL.EF.CATEGORY>();
            Mapper.CreateMap<DAL.EF.CATEGORY, Model.CategoryModel>();
            //News
            Mapper.CreateMap<Model.NewsModel, DAL.EF.NEWS>();
            Mapper.CreateMap<DAL.EF.NEWS, Model.NewsModel>();
            //Product
            Mapper.CreateMap<Model.ProductModel, DAL.EF.PRODUCT>();
            Mapper.CreateMap<DAL.EF.PRODUCT, Model.ProductModel>();
            //Role
            Mapper.CreateMap<Model.RoleModel, DAL.EF.ROLE>();
            Mapper.CreateMap<DAL.EF.ROLE, Model.RoleModel>();
            //Customer
            Mapper.CreateMap<Model.CustomerModel, DAL.EF.CUSTOMER>();
            Mapper.CreateMap<DAL.EF.CUSTOMER, Model.CustomerModel>();
            //Employee
            Mapper.CreateMap<Model.EmployeeModel, DAL.EF.EMPLOYEE>();
            Mapper.CreateMap<DAL.EF.EMPLOYEE, Model.EmployeeModel>();
        }
        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}