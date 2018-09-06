using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data.SystemData
{
    public class UserData
    {
        public System_User GetUserById(DataProvider dp, Guid userid)
        {
            return dp.System_User.Where(m => m.Id == userid).FirstOrDefault();
        }
    }
}
