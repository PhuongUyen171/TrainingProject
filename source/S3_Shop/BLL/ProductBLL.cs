using Models.DAL;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductBLL
    {
        private ProductDAL p;
        public ProductBLL()
        {
            p = new ProductDAL();
        }
        public List<PRODUCT> GetAllProduct()
        {
            return p.GetAllProduct();
        }
        public PRODUCT GetDetailProduct(int id)
        {
            return p.GetProductByID(id);
        }
        public List<PRODUCT> GetProductByCategory(int id)
        {
            return p.GetProductByCategory(id);
        }

        #region Insert, Update, Delete
        public bool InsertProduct(PRODUCT product)
        {
            return p.CreateProduct(product);
        }
        public bool UpdateProduct(PRODUCT product)
        {
            return p.UpdateProduct(product);
        }
        public bool DeleteProduct(int id)
        {
            return p.DeleteProduct(id);
        }
        #endregion
    }
}
