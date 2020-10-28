using BLL;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly StoreBLL st;
        public CategoryController()
        {
            st = new StoreBLL();
        }
        // GET: Category
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<STORE>>> GetSTOREs()
        //{
        //    return await st.GetAllStories();
        //}

        protected override void ExecuteCore()
        {
            throw new NotImplementedException();
        }
    }
}