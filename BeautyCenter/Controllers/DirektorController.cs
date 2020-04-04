using BeautyCenter.Models;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kursevi()
        {
            var kursevi = appContext.Direktor.Include(d => d.Saloni)
                .ThenInclude(d => d.Odrzuva)
                .ThenInclude(d => d.IdKursNavigation)
                .Where(d => d.IdVrabotenDirektorNavigation.EmailVraboten.Equals(User.Identity.Name)).Single();
            return View(kursevi);
        }

        



    }
}
