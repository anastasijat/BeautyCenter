using BeautyCenter.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace BeautyCenter.Controllers
{
    public class LoginController:Controller
    {
        private db_201920z_va_prj_beauty_centarContext appContext;

        public LoginController(db_201920z_va_prj_beauty_centarContext context)
        {
            appContext = context;
        }

        
        //[HttpGet]
        public IActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginUser(string userName, string password)
        {

            ClaimsIdentity identity = null;
            //bool isAuthenticated = false;
            if (appContext.Klienti.Any(k => k.EmailKlient.Equals(userName) && k.PasswordKlient.Equals(password)))//&& password == "#miha12")
            {
                
                identity = new ClaimsIdentity(
                    new[]
                    {
                            new Claim(ClaimTypes.Name,userName),
                            new Claim(ClaimTypes.Role,"Klienti")
                       
                    }, CookieAuthenticationDefaults.AuthenticationScheme); ;

                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                //isAuthenticated = true;

                return RedirectToAction("Index", "Klient");

            }

            if (appContext.Vraboteni.Any(v => v.EmailVraboten.Equals(userName) && v.PasswordVraboten.Equals(password) && appContext.Direktor.Any(d => d.IdVrabotenDirektor.Equals(v.IdVraboten))))
            {
                identity = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name,userName),
                        //new Claim(ClaimTypes.Name,password),
                        new Claim(ClaimTypes.Role,"Direktor")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Direktor");
            }

            if (appContext.Vraboteni.Any(v => v.EmailVraboten.Equals(userName) && v.PasswordVraboten.Equals(password) && appContext.Menadzer.Any(m => m.IdVrabotenMenadzer.Equals(v.IdVraboten))))
            {
                identity = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name,userName),
                        //new Claim(ClaimTypes.Name,password),
                        new Claim(ClaimTypes.Role,"Menadzer")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                //isAuthenticated = true;
                return RedirectToAction("Index", "Menadzer");
            }

            if (appContext.Vraboteni.Any(v=>v.EmailVraboten.Equals(userName) && v.PasswordVraboten.Equals(password)))
            {
                identity = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name,userName),
                        //new Claim(ClaimTypes.Name,password),
                        new Claim(ClaimTypes.Role,"Vraboteni")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                //isAuthenticated = true;
                return RedirectToAction("Index", "Vraboten");
            }

     
            return View();
            

        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LoginUser", "Login");
        }

    }
}
