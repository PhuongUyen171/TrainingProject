using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Common;
using DAL.DAL;

namespace BLL
{
    public class ProductBLL
    {
        ProductDAL pro = new ProductDAL();
        public List<Model.ProductModel> GetAllProducts()
        {
            EntityMapper<DAL.EF.PRODUCT, Model.ProductModel> mapObj = new EntityMapper<DAL.EF.PRODUCT, Model.ProductModel>();
            List<DAL.EF.PRODUCT> list = new ProductDAL().GetAllProducts();
            List<Model.ProductModel> products = new List<Model.ProductModel>();
            foreach (var item in list)
            {
                products.Add(mapObj.Translate(item));
            }
            return (List<Model.ProductModel>)products;
        }
        public Model.ProductModel GetProductByID(int id)
        {
            EntityMapper<DAL.EF.PRODUCT, Model.ProductModel> mapObj = new EntityMapper<DAL.EF.PRODUCT, Model.ProductModel>();
            DAL.EF.PRODUCT product = new ProductDAL().GetProductByID(id);
            Model.ProductModel result = new Model.ProductModel();
            result = mapObj.Translate(product);
            return result;
        }
        public List<Model.ProductModel> GetProductsByCateID(int id)
        {
            EntityMapper<DAL.EF.PRODUCT, Model.ProductModel> mapObj = new EntityMapper<DAL.EF.PRODUCT, Model.ProductModel>();
            List<DAL.EF.PRODUCT> list = new ProductDAL().GetProductsByCategoryID(id);
            List<Model.ProductModel> products = new List<Model.ProductModel>();
            foreach (var item in list)
            {
                products.Add(mapObj.Translate(item));
            }
            return (List<Model.ProductModel>)products;
        }
        public List<Model.ProductModel> GetNewProductsByCount(int count)
        {
            EntityMapper<DAL.EF.PRODUCT, Model.ProductModel> mapObj = new EntityMapper<DAL.EF.PRODUCT, Model.ProductModel>();
            List<DAL.EF.PRODUCT> list = new ProductDAL().GetNewProductsByCount(count);
            List<Model.ProductModel> products = new List<Model.ProductModel>();
            foreach (var item in list)
            {
                products.Add(mapObj.Translate(item));
            }
            return (List<Model.ProductModel>)products;
        }
    }
}
