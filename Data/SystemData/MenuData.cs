using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Model.SystemModel;

namespace Data.SystemData
{
    public class MenuData
    {
        public List<System_Menu> GetMenuByParentId(DataProvider dp, Guid parentId)
        {
            return dp.System_Menu.Where(m => m.ParentId == parentId && m.IsDel == false).ToList();
        }

        public System_Menu GetMenuById(DataProvider dp, Guid id)
        {
            return dp.System_Menu.FirstOrDefault(m => m.Id == id && m.IsDel == false);
        }

    }
}
