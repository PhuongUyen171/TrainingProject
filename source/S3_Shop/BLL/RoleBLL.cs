using Models.DAL;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoleBLL
    {
        RoleDAL r;
        public RoleBLL()
        {
            r = new RoleDAL();
        }
        public IEnumerable<ROLE> GetAllRoles()
        {
            return r.GetAllRoles();
        }
        public ROLE GetDetailRole(int id)
        {
            return r.GetRoleByID(id);
        }

        #region CRUD
        public void CreatNewRole(ROLE r)
        {

        }
        #endregion
    }
}
