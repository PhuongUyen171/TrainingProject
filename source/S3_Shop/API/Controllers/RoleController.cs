using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using BLL;

namespace API.Controllers
{
    public class RoleController : Controller
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public List<Model.RoleModel> GetAllRoles()
        {
            return new RoleBLL().GetAllRoles();
        }
    }
}