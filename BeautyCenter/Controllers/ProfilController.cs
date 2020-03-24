using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BeautyCenter.Controllers
{
    public class ProfilController:Controller
    {
        private db_201920z_va_prj_beauty_centarContext appContext;

        public ProfilController(db_201920z_va_prj_beauty_centarContext context)
        {
            appContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LoginUser", "Login");
        }
    }
}
