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
    public class MenuBusiness
    {
        MenuData data = new MenuData();
        public List<MenuModel>  GetAllMenu()
        {
            using (DataProvider dp = new DataProvider())
            {
                return GetChildMenu(dp, Guid.Empty);
            }
        }

        public List<MenuModel> GetChildMenu(DataProvider dp, Guid parnetId)
        {
            List<MenuModel> list = new List<MenuModel>();
            foreach (var m in data.GetMenuByParentId(dp, parnetId))
            {
                MenuModel model = Mapper.Map<MenuModel>(m);
                model.Children = GetChildMenu(dp, model.Id);
                list.Add(model);
            }
            return list;
        }
    }
}
