using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeautyCenter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BeautyCenter.Controllers
{
    
    public class HomeController : Controller
    {
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        private db_201920z_va_prj_beauty_centarContext appContext;

        public HomeController(db_201920z_va_prj_beauty_centarContext context)
        {
            appContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registracija()
        {
            
            return View(appContext.Opshtini.ToList());
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //******

        public IActionResult Saloni()
        {
            var saloni = appContext.Saloni
                .Include(s => s.IdOpshtinaNavigation).ToList();
            return View(saloni);
        }
        
         public IActionResult Salon(int id)
        {
            //var salon = new HomeSalonViewModel();
            var salon = appContext.Saloni
                .Include(s=>s.Oddeli)
                .ThenInclude(s=>s.Uslugi)
                .Where(s => s.IdSalon == id).Single();
            return View (salon);
        }

        public async Task<IActionResult> Search(string searchString)
        {
            var saloni = from s in appContext.Saloni select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                saloni = saloni.Where(ss => ss.ImeSalon.Contains(searchString));

            }

            return View(saloni.ToList());
        }

       

        public IActionResult OpisUsluga(int id)
        {
            var usluga = appContext.Uslugi
                .Include(u=>u.IdOddelNavigation)
                .Where(u => u.IdUsluga == id)
                .Single();
            return View(usluga);
        }

        public int randomId()
        {
            Random random = new Random();
            return random.Next(10000);
        }


        [HttpPost]
        public IActionResult Registracija(string imeIprezime, string email, string lozinka, string telBroj, string opshtina)
        {
           
            if (!appContext.Klienti.Any(k => k.EmailKlient.Equals(email)))
            {
                int id = randomId();
                while (appContext.Klienti.Any(k => k.IdKlient.Equals(id)))
                {
                    id = randomId();
                }
                if (!appContext.Klienti.Any(k => k.IdKlient.Equals(id)))
                {
                    var opstinaO = appContext.Opshtini.Where(o => o.NazivOpshtina.Equals(opshtina)).Single();
                    
                    var klient = new Klienti { IdKlient = id, ImeKlient = imeIprezime, EmailKlient = email, PasswordKlient = lozinka, TelBrojKlient = telBroj, IdOpshtinaZhiveenje = opstinaO.IdOpshtina };
                    appContext.Klienti.Add(klient);
                    appContext.SaveChanges();
                    return RedirectToAction("LoginUser", "Login");
                }

            }

            return RedirectToAction("Registracija", "Home");



        }
        //*****


    }
}
