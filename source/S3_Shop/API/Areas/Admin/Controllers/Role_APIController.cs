using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Model;

namespace API.Areas.Admin.Controllers
{
    public class Role_APIController : ApiController
    {
        RoleBLL roleBll = new RoleBLL();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public List<Model.RoleModel> GetAllRoles()
        {
            return new RoleBLL().GetAllRoles();
        }
        public bool InsertRole(RoleModel role)
        {
            return new RoleBLL().InsertRole(role);
        }
        public bool DeleteRole(int id)
        {
            return roleBll.DeleteRole(id);
        }
        public bool UpdateRole(RoleModel role)
        {
            return new RoleBLL().UpdateRole(role);
        }

        public RoleModel GetDetailRole(int id)
        {
            return new RoleBLL().GetRoleByID(id);
        }
    }
}