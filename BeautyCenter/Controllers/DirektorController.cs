using BeautyCenter.Models;
using Microsoft.AspNetCore.Mvc;
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

        
    }
}
