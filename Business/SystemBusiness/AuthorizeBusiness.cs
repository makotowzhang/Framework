using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.SystemModel;
using Entity;
using Data.SystemData;

namespace Business.SystemBusiness
{
    public class AuthorizeBusiness
    {
        AuthorizeData data = new AuthorizeData();
        public bool SetAuthorize(AuthorizeModel model)
        {
            if (model.RoleId == Guid.Empty || model.MenuIdList == null)
            {
                return false;
            }
            using (DataProvider dp = new DataProvider())
            {
                data.DeleteAuthorize(dp,data.GetAuthorizeListByRoleId(dp, model.RoleId));
                foreach (Guid menuId in model.MenuIdList)
                {
                    data.AddAuthorize(dp, new System_Authorize()
                    {
                        MenuId=menuId,
                        RoleId=model.RoleId,
                        CreateUser=model.CreateUser,
                        CreateTime=DateTime.Now
                    });
                }
                dp.SaveChanges();
                return true;
            }
        }


        public List<Guid?> GetRoleAuthorize(Guid roleId)
        {
            using (DataProvider dp = new DataProvider())
            {
                return data.GetAuthorizeListByRoleId(dp, roleId).Select(m => m.MenuId).ToList();
            }
        }
    }
}
