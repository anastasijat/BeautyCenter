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

        [Authorize(Roles = "Klienti")]
        public IActionResult Index()
        {
            return View();
        }
        //*****

        [Authorize(Roles = "Klienti")]
        public IActionResult Saloni()
        {
            var saloni = appContext.Saloni
                .Include(s => s.IdOpshtinaNavigation).ToList();
            return View(saloni);
        }

        [Authorize(Roles = "Klienti")]
        public IActionResult Salon(int id)
        {
            //var salon = new HomeSalonViewModel();
            var salon = appContext.Saloni
                .Include(s => s.Oddeli)
                .ThenInclude(s => s.Uslugi)
                .Where(s => s.IdSalon == id).Single();
            return View(salon);
        }

        [Authorize(Roles = "Klienti")]
        public async Task<IActionResult> Search(string searchString)
        {
            var saloni = from s in appContext.Saloni select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                saloni = saloni.Where(ss => ss.ImeSalon.Contains(searchString));

            }

            return View(saloni.ToList());
        }

        [Authorize(Roles = "Klienti")]
        public IActionResult OpisUsluga(int id)
        {
            var usluga = appContext.Uslugi
                .Include(u => u.IdOddelNavigation)
                .Where(u => u.IdUsluga == id)
                .Single();
            return View(usluga);
        }

        [Authorize(Roles = "Klienti")]
        public IActionResult OmileniUslugi()
        {
            var omileni = appContext.Omileni
                .Include(o => o.IdUslugaNavigation)
                .ThenInclude(o => o.IdOddelNavigation)
                .ThenInclude(o => o.IdSalonNavigation)
                .Where(o => o.IdKlientNavigation.EmailKlient.Equals(User.Identity.Name)).ToList();

            return View(omileni);
        }


        //*****






        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Klienti")]
        public IActionResult DodadiOmilena(int id)
        {
            
            var omileniNew = new Omileni { IdKlient = ((BeautyCenter.Models.Klienti)appContext.Klienti.Where(k => k.EmailKlient.Equals(User.Identity.Name))).IdKlient, IdUsluga = id };

            
                appContext.Omileni.Add(omileniNew);
                appContext.SaveChanges();
                return RedirectToAction("Index", "Klient");
            
            
            
            
        }
        
       
    }
}
