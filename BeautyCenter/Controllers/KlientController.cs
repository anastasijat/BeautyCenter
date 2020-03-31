using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize(Roles = "Klienti")]
        public async Task<IActionResult> OmileniUslugi()
        {
            var viewModel = new OmileniViewModel();
            viewModel.Omilenis = await appContext.Omileni
                .Include(o => o.IdUslugaNavigation)
                .Where(o => o.IdKlientNavigation.EmailKlient.Equals(User.Identity.Name)).ToListAsync();
            return View(viewModel);
        }

        public IActionResult Uslugi()
        {
            return View(appContext.Uslugi.ToList().GroupBy(u => u.ImeUsluga).Select(grp => grp.First()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Klienti")]
        public IActionResult DodadiOmilena(int id)
        {
            
                var omileniNew = new Omileni { IdKlient = ((BeautyCenter.Models.Klienti)appContext.Klienti.Where(k => k.EmailKlient.Equals(User.Identity.Name))).IdKlient, IdUsluga = id };

            if (ModelState.IsValid)
            {
                appContext.Omileni.Add(omileniNew);
                appContext.SaveChanges();
                return RedirectToAction("Index", "Klient");
            }

            return View();
            
            
            
            
        }
        
       
    }
}
