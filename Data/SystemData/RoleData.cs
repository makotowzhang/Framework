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
        public List<System_Role> GetUserRole(DataProvider dp,Guid userId)
        {
            return dp.System_Role.Where(m => dp.System_UserRole.Where(x => x.UserId == userId).Select(x =>(Guid)x.RoleId).Contains(m.Id)).ToList();
        }
    }
}
