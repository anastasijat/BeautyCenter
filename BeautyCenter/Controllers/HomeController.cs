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


        //[Authorize(Roles ="Klienti")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Uslugi()
        {
            var viewModel = new UslugiHomeViewModel();
            viewModel.Oddelis = await appContext.Oddeli
                .Include(o => o.Uslugi).ToListAsync();

            return View(viewModel);
        }
    }
}
