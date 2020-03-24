using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Models;

namespace BeautyCenter.Controllers
{
    public class SaloniController:Controller
    {

        private db_201920z_va_prj_beauty_centarContext appContext;

        public SaloniController(db_201920z_va_prj_beauty_centarContext context)
        {
            appContext = context;
        }

       // public string SearchString { get; set; }
        public IActionResult Index()
        {
            return View(appContext.Saloni.ToList());
        }

        //GET: /Saloni/Salon/1
        public IActionResult Salon(int id)
        {
            var saloni = from s in appContext.Saloni select s;
            saloni = saloni.Where(ss => ss.IdSalon.Equals(id));
            return View(saloni.ToList());
            

        }

        
        public async Task<IActionResult> Search(string searchString)
        {
            var saloni = from s in appContext.Saloni select s;
            if(!String.IsNullOrEmpty(searchString))
            {
                saloni = saloni.Where(ss => ss.ImeSalon.Contains(searchString));

            }

            return View(saloni.ToList());
        }
    }
}
