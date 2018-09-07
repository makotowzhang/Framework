using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Model.SystemModel;
using AutoMapper;
using Data.SystemData;

namespace Business.SystemBusiness
{
    public class UserBusiness
    {
        UserData data = new UserData();

        public List<UserModel> GetUserList(UserFilter filter,out int total, bool IsPage = true)
        {
            using (DataProvider dp = new DataProvider())
            {
                List<UserModel> list = new List<UserModel>();
                RoleData roleData = new RoleData();
                foreach (var m in data.GetUserList(dp, filter,out total, IsPage))
                {
                    UserModel model = Mapper.Map<UserModel>(m);
                    model.UserRole = new List<RoleModel>();
                    List<System_Role> roleList = roleData.GetUserRole(dp, m.Id);
                    if (roleList != null && roleList.Count > 0)
                    {
                        foreach (var role in roleList)
                        {
                            model.UserRole.Add(Mapper.Map<RoleModel>(m));
                        }
                    }
                    list.Add(model);
                }
                return list;
            }
        }

        public bool AddUser(UserModel model, Guid userId)
        {
            System_User entity = Mapper.Map<System_User>(model);
            entity.Id = Guid.NewGuid();
            entity.IsDel = false;
            entity.CreateUser = userId;
            entity.CreateTime = DateTime.Now;
            List<System_UserRole> userRoleList = new List<System_UserRole>();
            if (model.AddRoleId != null && model.AddRoleId.Count > 0)
            {
                foreach (var m in model.AddRoleId)
                {
                    userRoleList.Add(new System_UserRole()
                    {
                        UserId = entity.Id,
                        RoleId = m,
                        CreateUser = userId,
                        CreateTime = DateTime.Now
                    });
                }
            }
            using (DataProvider dp = new DataProvider())
            {
                data.AddUser(dp,entity);
                if (userRoleList.Count > 0)
                {
                    data.AddUserRole(dp, userRoleList);
                }
                try
                {
                    dp.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool EditUser(UserModel model, Guid userId)
        {
            List<System_UserRole> userRoleList = new List<System_UserRole>();
            if (model.AddRoleId != null && model.AddRoleId.Count > 0)
            {
                foreach (var m in model.AddRoleId)
                {
                    userRoleList.Add(new System_UserRole()
                    {
                        UserId = model.Id,
                        RoleId = m,
                        CreateUser = userId,
                        CreateTime = DateTime.Now
                    });
                }
            }
            using (DataProvider dp = new DataProvider())
            {
                System_User entity = data.GetUserById(dp, model.Id);
                entity.UserName = model.UserName;
                entity.TrueName = model.TrueName;
                entity.IsEnabled = model.IsEnabled;
                entity.UpdateUser = userId;
                entity.UpdateTime = DateTime.Now;
                data.DeleteUserRole(dp, model.Id);
                if (userRoleList.Count > 0)
                {
                    data.AddUserRole(dp, userRoleList);
                }
                try
                {
                    dp.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool CheckUserNameExsit(UserModel model, bool isUpdate=false)
        {
            using (DataProvider dp = new DataProvider())
            {
                return data.GetUserNameCount(dp, model, isUpdate) > 0;
            }
        }
    }
}
