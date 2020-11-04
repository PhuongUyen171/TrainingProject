using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Areas.Admin.Controllers
{
    public class Membership_APIController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public List<Model.MembershipModel> GetAllMemberships()
        {
            return new MembershipBLL().GetAllMemberships();
        }
        public Model.MembershipModel GetMembershipByID(string id)
        {
            return new MembershipBLL().GetMembershipByID(id);
        }
        // GET: Admin/Membership
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}