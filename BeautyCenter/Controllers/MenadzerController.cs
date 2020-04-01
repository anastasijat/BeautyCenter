using BeautyCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyCenter.Controllers
{
    public class MenadzerController:Controller
    {

        private db_201920z_va_prj_beauty_centarContext appContext;

        public MenadzerController(db_201920z_va_prj_beauty_centarContext context)
        {
            appContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vraboteni()
        {
            /*var vraboteni = appContext.Vraboteni
                 .Include(v => v.IdRmNavigation)
                 .ThenInclude(v=>v.Oddeli)

                 .ToList();*/


            Vraboteni vraboten = (BeautyCenter.Models.Vraboteni)appContext.Vraboteni.Where(v => v.EmailVraboten.Equals(User.Identity.Name));
            var vraboteni = appContext.Menadzer
                .Include(v => v.Oddeli)
                .ThenInclude(v => v.IdRmNavigation)
                .ThenInclude(v => v.Vraboteni)
                .Where(v => v.IdVrabotenMenadzerNavigation.EmailVraboten.Equals(User.Identity.Name)).ToList();


                

            return View();
        }
        
    }
}
