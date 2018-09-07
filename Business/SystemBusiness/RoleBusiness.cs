using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.SystemModel;
using Data.SystemData;
using Entity;
using AutoMapper;

namespace Business.SystemBusiness
{
    public class RoleBusiness
    {
        RoleData data = new RoleData();
        public bool AddRole(RoleModel model,Guid userId)
        {
            System_Role entity = Mapper.Map<System_Role>(model);
            entity.Id = Guid.NewGuid();
            entity.IsDel = false;
            entity.CreateUser = userId;
            entity.CreateTime = DateTime.Now;
            using (DataProvider dp = new DataProvider())
            {
                data.AddRole(dp, entity);
                return dp.SaveChanges()==1;
            }
        }

        public bool UpdateRole(RoleModel model, Guid userId)
        {
            using (DataProvider dp = new DataProvider())
            {
                System_Role entity = data.GetModel(dp, model.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.RoleName = model.RoleName;
                entity.RoleDesc = model.RoleDesc;
                entity.Sort = model.Sort;
                entity.IsEnabled = model.IsEnabled;
                entity.UpdateUser = userId;
                entity.UpdateTime = DateTime.Now;
                return dp.SaveChanges() == 1;
            }
        }
    }
}
