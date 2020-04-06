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
                .Include(u=>u.Termini)
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

        [Authorize(Roles = "Klienti")]
        public IActionResult MoiTermini()
        {
            var termini = appContext.Termini
                .Include(t => t.IdUslugaNavigation)
                .ThenInclude(t => t.IdOddelNavigation)
                .ThenInclude(t => t.IdSalonNavigation)
                .Where(t => t.IdKlientNavigation.EmailKlient.Equals(User.Identity.Name)).ToList();
            return View(termini);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Klienti")]
        public IActionResult DodadiOmilena(int id)
        {

            var klient = appContext.Klienti.Where(k => k.EmailKlient.Equals(User.Identity.Name)).Single();

            var omileniNew = new Omileni { IdKlient = klient.IdKlient, IdUsluga = id };
            appContext.Omileni.Add(omileniNew);
            appContext.SaveChanges();
            return View();
            // else da dopolnam !!!!
        }


        [Authorize(Roles = "Klienti")]
        public IActionResult Kursevi()
        {
            var kursevi = appContext.Kursevi.ToList();
            return View(kursevi);

        }

        [Authorize(Roles = "Klienti")]
        public IActionResult Kurs(int id)
        {
            var kurs = appContext.Kursevi
                .Include(k => k.Odrzuva).ThenInclude(k => k.IdSalonNavigation)
                .Include(k => k.Predava).ThenInclude(k => k.IdPredavacNavigation)
                .Where(k => k.IdKurs == id).Single();
            return View(kurs);
        }

        [Authorize(Roles = "Klienti")]
        public IActionResult PrijavaZaKurs(int id)
        {
            var klient = appContext.Klienti.Where(k => k.EmailKlient.Equals(User.Identity.Name)).Single();
            if (!appContext.Posetuva.Any(p => p.IdKlient == klient.IdKlient && p.IdKurs == id))
            {
                var posetuva = new Posetuva { IdKlient = klient.IdKlient, IdKurs = id };
                appContext.Posetuva.Add(posetuva);
                appContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Message"] = "Веќе се пријавивте на овој курс";
                return View("Alert");
            }

        }

        //*****













    }
}
