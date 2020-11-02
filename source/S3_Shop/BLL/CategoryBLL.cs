using BLL.Common;
using DAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBLL
    {
        CategoryDAL cate = new CategoryDAL();
        public List<Model.CategoryModel> GetAllCategories()
        {
            EntityMapper<DAL.EF.CATEGORY, Model.CategoryModel> mapObj = new EntityMapper<DAL.EF.CATEGORY, Model.CategoryModel>();
            List<DAL.EF.CATEGORY> cateList = new CategoryDAL().GetAllCategories();
            List<Model.CategoryModel> categories = new List<Model.CategoryModel>();
            foreach (var item in cateList)
            {
                categories.Add(mapObj.Translate(item));
            }
            return (List<Model.CategoryModel>)categories;
        }
    }
}
