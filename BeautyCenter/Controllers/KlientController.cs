using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Internal;

namespace BeautyCenter.Controllers
{
    public class KlientController:Controller
    {
        private db_201920z_va_prj_beauty_centarContext appContext;

        public KlientController(db_201920z_va_prj_beauty_centarContext context)
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

     
        public async Task<IActionResult> OmileniUslugi()
        {
            var viewModel = new OmileniViewModel();
            viewModel.Omilenis = await appContext.Omileni
                .Include(o => o.IdUslugaNavigation)
                .Where(o => o.IdKlientNavigation.EmailKlient.Equals(User.Identity.Name)).ToListAsync();
            return View(viewModel);
        }

        
       
    }
}
