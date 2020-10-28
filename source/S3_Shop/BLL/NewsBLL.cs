using Models.DAL;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NewsBLL
    {
        NewsDAL n;
        public NewsBLL()
        {
            n = new NewsDAL();
        }
        public IEnumerable<NEWS> GetAllNews()
        {
            return n.GetAllNews();
        }
        public NEWS GetDetailNews(int id)
        {
            return n.GetNewsByID(id);
        }
        

        #region CRUD
        public void CreatNews(NEWS s)
        {

        }
        #endregion
    }
}
