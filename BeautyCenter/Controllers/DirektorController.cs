using BeautyCenter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Controllers
{
    public class DirektorController:Controller
    {

        private db_201920z_va_prj_beauty_centarContext appContext;

        public DirektorController(db_201920z_va_prj_beauty_centarContext context)
        {
            appContext = context;
        }

        [Authorize(Roles="Direktor")]
        public IActionResult Index()
        {
            return View();
        }

        public int randomId()
        {
            Random random = new Random();
            return random.Next(10000);
        }

        [Authorize(Roles = "Direktor")]
        public IActionResult Kursevi()
        {
            var kursevi = appContext.Direktor.Include(d => d.Saloni)
                .ThenInclude(d => d.Odrzuva)
                .ThenInclude(d => d.IdKursNavigation)
                .Where(d => d.IdVrabotenDirektorNavigation.EmailVraboten.Equals(User.Identity.Name)).Single();
            return View(kursevi);
        }



        [Authorize(Roles = "Direktor")]
        public IActionResult NovKurs()
        {
            return View();
        }

        [Authorize(Roles = "Direktor")]
        public IActionResult DodadiKurs(string ImeKurs, int CenaKurs)
        {
            var direktor = appContext.Direktor
                .Where(d => d.IdVrabotenDirektorNavigation.EmailVraboten.Equals(User.Identity.Name)).Single();

            var salon = appContext.Saloni
                .Include(s => s.Odrzuva)
                .Where(s => s.IdVrabotenDirektorNavigation.IdVrabotenDirektor.Equals(direktor.IdVrabotenDirektor)).FirstOrDefault();

            int id = randomId();
            while (appContext.Kursevi.Any(k => k.IdKurs.Equals(id)))
            {
                id = randomId();
            }
            var kurs = new Kursevi { IdKurs = id, ImeKurs = ImeKurs, CenaKurs = CenaKurs };
            var kursNew = new Odrzuva { IdSalon = salon.IdSalon, IdKurs = kurs.IdKurs };

            appContext.Kursevi.Add(kurs);
            appContext.Odrzuva.Add(kursNew);
            appContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Direktor")]
        public IActionResult Vraboteni()
        {
            var direktor = appContext.Direktor
                .Where(d => d.IdVrabotenDirektorNavigation.EmailVraboten.Equals(User.Identity.Name)).Single();
            var vraboteni = appContext.Saloni
                .Include(s=>s.Vraboteni)
                .Where(s => s.IdVrabotenDirektorNavigation.IdVrabotenDirektor.Equals(direktor.IdVrabotenDirektor)).ToList();

            return View(vraboteni);
        }








    }
}
