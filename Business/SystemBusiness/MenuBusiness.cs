﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.SystemModel;
using Model.EnumModel;
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


        public bool AddMenu(MenuModel model,out Guid menuId)
        {
            System_Menu entity = Mapper.Map<System_Menu>(model);
            if (entity.MenuType == MenuType.Root.ToString())
            {
                entity.MenuUrl = null;
                entity.ActionCode = null;
                entity.ActionDesc = null;
                entity.ParentId = Guid.Empty;
            }
            if (entity.MenuType == MenuType.Group.ToString())
            {
                entity.MenuUrl = null;
                entity.ActionCode = null;
                entity.ActionDesc = null;
            }
            if (entity.MenuType == MenuType.Router.ToString())
            { 
                entity.ActionCode = null;
                entity.ActionDesc = null;
            }
            if (entity.MenuType == MenuType.Action.ToString())
            {
                entity.MenuUrl = null;
                entity.IconClass = "icon iconfont icon-thunderbolt-fill";
            }
            entity.Id = Guid.NewGuid();
            entity.IsDel = false;
            entity.CreateTime = DateTime.Now;
            using (DataProvider dp = new DataProvider())
            {
                data.AddMenu(dp, entity);
                if (entity.MenuType == MenuType.Router.ToString())
                {
                    data.AddMenu(dp, new System_Menu()
                    {
                        Id = Guid.NewGuid(),
                        MenuName="浏览",
                        MenuType=MenuType.Action.ToString(),
                        ParentId=entity.Id,
                        Sort=-1,
                        ActionCode="View",
                        ActionDesc="默认动作",
                        CreateTime=DateTime.Now,
                        CreateUser=entity.CreateUser,
                        IsEnabled=true,
                        IsDel=false,
                        IconClass= "icon iconfont icon-thunderbolt-fill"
                    });
                }
                dp.SaveChanges();
                menuId = entity.Id;
                return true;
            }
        }

        public bool EditMenu(MenuModel model)
        {
            using (DataProvider dp = new DataProvider())
            {
                System_Menu entity = data.GetMenuById(dp, model.Id);
                entity.MenuName = model.MenuName;
                entity.UpdateUser = model.UpdateUser;
                entity.UpdateTime = DateTime.Now;
                entity.IsEnabled = model.IsEnabled;
                entity.Sort = model.Sort;
                if (entity.MenuType != MenuType.Action.ToString())
                {
                    entity.IconClass = model.IconClass;
                }
                if (entity.MenuType == MenuType.Router.ToString())
                {
                    entity.MenuUrl = model.MenuUrl;
                }
                if (entity.MenuType == MenuType.Action.ToString())
                {
                    entity.ActionCode = model.ActionCode;
                    entity.ActionDesc = model.ActionDesc;
                }
                dp.SaveChanges();
                return true;
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

        public MenuModel GetMenuById(Guid menuId)
        {
            using (DataProvider dp = new DataProvider())
            {
                return Mapper.Map<MenuModel>(data.GetMenuById(dp, menuId));
            }
        }
    }
}