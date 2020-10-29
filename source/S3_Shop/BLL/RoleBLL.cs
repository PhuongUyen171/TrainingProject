using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DAL;
using Models.EF;

namespace BLL
{
    public class RoleBLL
    {
        private RoleDAL r;
        public RoleBLL()
        {
            r = new RoleDAL();
        }
        public ROLE GetDetailRole(int id)
        {
            return r.GetRoleByID(id);
        }
        public bool InsertNewRole(ROLE role)
        {
            return r.CreateRole(role);
        }
        public bool UpdateRole(ROLE role)
        {
            return r.UpdateRole(role);
        }
        public bool DeleteRole(int id)
        {
            return r.DeleteRole(id);
        }
        public List<ROLE> GetAllRoles()
        {
            return r.GetAllRoles();
        }
    }
}
