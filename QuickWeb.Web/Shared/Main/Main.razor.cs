using System;
using System.Collections.Generic;

namespace QuickWeb.Web.Shared.Main
{
    public class MenuTabl
    {
        public String Title { get; set; }
        public String Url { get; set; }
    }

    public partial class Main
    {
        private List<MenuTabl> message = new List<MenuTabl>()
        {
            new MenuTabl()
            {
                Title="公告",
                Url="https://www.baidu.com"
            },
            new MenuTabl()
            {
                Title="消息",
                Url="https://www.baidu.com"
            }
        };

        private List<MenuTabl> userinfo = new List<MenuTabl>()
        {
            new MenuTabl()
            {
                Title="用户信息",
                Url="https://www.baidu.com"
            },
            new MenuTabl()
            {
                Title="注销",
                Url="/LogIn"
            }
        };

        private List<HeadTab> tabs = new List<HeadTab>()
        {
            new HeadTab()
            {
                Tab = "首页", Checked = true, Url = "/View"
            }
        };

        private List<MenuObject> _menu = new List<MenuObject>()
        {
            new MenuObject()
            {
                Title = "系统管理",
                Tab = new Dictionary<string, string>()
                {
                    { "用户管理", "/View/UserManagement" },
                    { "角色管理", "https://www.baidu.com" },
                    { "菜单管理", "https://www.baidu.com" },
                    { "租户管理", "https://www.baidu.com" },
                    { "用户管理1", "/View/UserManagement" },
                    { "角色管理1", "https://www.baidu.com" },
                    { "菜单管理1", "https://www.baidu.com" },
                    { "租户管理1", "https://www.baidu.com" },
                    { "用户管理2", "/View/UserManagement" },
                    { "角色管理2", "https://www.baidu.com" },
                    { "菜单管理2", "https://www.baidu.com" },
                    { "租户管理2", "https://www.baidu.com" },
                    { "用户管理3", "/View/UserManagement" },
                    { "角色管理3", "https://www.baidu.com" },
                    { "菜单管理3", "https://www.baidu.com" },
                    { "租户管理3", "https://www.baidu.com" },
                    { "用户管理4", "/View/UserManagement" },
                    { "角色管理4", "https://www.baidu.com" },
                    { "菜单管理4", "https://www.baidu.com" },
                    { "租户管理4", "https://www.baidu.com" },
                    { "用户管理5", "/View/UserManagement" },
                    { "角色管理5", "https://www.baidu.com" },
                    { "菜单管理5", "https://www.baidu.com" },
                    { "租户管理5", "https://www.baidu.com" }
                },
                Show =  false
            }
        };
    }
}