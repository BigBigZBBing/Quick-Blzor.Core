using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickWeb.Web.Helper;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuickWeb.Web.Pages
{
    [AllowAnonymous]
    public class LoginInModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync(String UserName, String Password)
        {
            string returnUrl = Url.Content("~/View/Index");
            try
            {
                // 清除现有的外部Cookie
                await HttpContext
                    .SignOutAsync("Quick.Web.Cookie");
            }
            catch { }

            //跳转回主页面
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                return LocalRedirect(returnUrl);

            // *** !!! 在这里您可以验证用户 !!! ***
            // 在此示例中，我们仅登录用户（此示例始终登录用户）
            //
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, DESHelper.Decrypt(UserName)),
                new Claim(ClaimTypes.Role, "Administrator")
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Quick.Web.Cookie");
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = this.Request.Host.Value,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
            };
            try
            {
                await HttpContext.SignInAsync(
                "Quick.Web.Cookie",
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
                returnUrl = Url.Content("~/Main");
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return LocalRedirect(returnUrl);
        }
    }
}