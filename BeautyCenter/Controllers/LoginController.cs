﻿using BeautyCenter.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            bool isAuthenticated = false;
            if (appContext.Klienti.Any(k => k.EmailKlient.Equals(userName) && k.PasswordKlient.Equals(password)))//&& password == "#miha12")
            {
                identity = new ClaimsIdentity(
                    new[]
                    {
                            new Claim(ClaimTypes.Name,userName),
                            new Claim(ClaimTypes.Name,password),
                            new Claim(ClaimTypes.Role,"Klienti")
                        //new Claim(ClaimTypes.Role,"Klienti")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                isAuthenticated = true;
                //return RedirectToAction("Index", "Home");
            }
             
            
            if(isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            return View();
            

        }

        
    }
}
