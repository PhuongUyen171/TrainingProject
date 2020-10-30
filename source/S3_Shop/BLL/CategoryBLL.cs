using Models.DAL;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBLL
    {
        private CategoryDAL c;
        public CategoryBLL()
        {
            c = new CategoryDAL();
        }
        public List<CATEGORY> GetAllCategory()
        {
            return c.GetAllCategories();
        }
        public CATEGORY GetDetailCategory(int id)
        {
            return c.GetCategoryByID(id);
        }

        #region Insert, Update, Delete
        public bool InsertCategory(CATEGORY cate)
        {
            return c.CreateCategory(cate);
        }
        public bool DeleteCategory(int id)
        {
            return c.DeteleCategory(id);
        }
        public bool UpdateCategory(CATEGORY cate)
        {
            return c.UpdateCategory(cate);
        }
        #endregion
    }
}
