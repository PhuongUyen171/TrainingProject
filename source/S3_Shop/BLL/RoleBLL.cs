using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Common;
using DAL.DAL;

namespace BLL
{
    public class RoleBLL
    {
        RoleDAL role = new RoleDAL();
        public List<Model.RoleModel> GetAllRoles()
        {
            EntityMapper<DAL.EF.ROLE, Model.RoleModel> mapObj = new EntityMapper<DAL.EF.ROLE, Model.RoleModel>();
            List<DAL.EF.ROLE> list = new RoleDAL().GetAllRoles();
            List<Model.RoleModel> roles = new List<Model.RoleModel>();
            foreach (var item in list)
            {
                roles.Add(mapObj.Translate(item));
            }
            return (List<Model.RoleModel>)roles;
        }
    }
}
