using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuickWeb.Web.Shared.Login
{
    public class LoginViewModel
    {
        [Description("用户名")]
        [Required(ErrorMessage = "用户名是必填项")]
        [StringLength(10, ErrorMessage = "用户名不能超{1}位")]
        public String UserName { get; set; }

        [Description("密码")]
        [Required(ErrorMessage = "密码是必填项")]
        [StringLength(8, ErrorMessage = "密码不能超{1}位")]
        public String Password { get; set; }
    }
}