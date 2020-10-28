using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models.EF;
using BLL;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.SqlServer.Server;
using System.Web.Mvc.Routing;

namespace API.Controllers
{
    public class StoreController : ApiController
    {
        // GET: api/Store

        StoreBLL s = new StoreBLL();
        
        //private readonly StoreBLL _s;
        //public StoreController(StoreBLL s)
        //{
        //    _s = s;
        //}

        [System.Web.Mvc.Route("lay-tat-ca-chi-nhanh")]
        public IEnumerable<STORE> GetAllStories()
        {
            return s.GetAllStories();
        }

        // GET: api/Store/5
        [System.Web.Mvc.Route("chi-nhanh/{lc}")]
        public IEnumerable<STORE> GetStoriesByLocation(string local)
        {
            return s.GetStoreByLocation(local); 
        }
        //public STORE GetStoreByID(int id)
        //{
        //    return s.GetDetailStory(id);
        //}

        // POST: api/Store
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Store/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Store/5
        public void Delete(int id)
        {
        }
    }
}
