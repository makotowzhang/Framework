using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data.SystemData
{
    public class RoleData
    {
        public System_Role GetModel(DataProvider dp, Guid roleId)
        {
            return dp.System_Role.FirstOrDefault(m => m.Id == roleId);
        }

        public void AddRole(DataProvider dp, System_Role entity)
        {
            dp.System_Role.Add(entity);
        }

        public List<System_Role> GetUserRole(DataProvider dp,Guid userId)
        {
            return dp.System_Role.Where(m => dp.System_UserRole.Where(x => x.UserId == userId).Select(x =>(Guid)x.RoleId).Contains(m.Id)).ToList();
        }
    }
}
