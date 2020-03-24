using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCenter.Controllers
{
    public class UslugiController:Controller
    {
        private db_201920z_va_prj_beauty_centarContext appContext;

        public UslugiController(db_201920z_va_prj_beauty_centarContext context)
        {
            appContext = context;
        }

        public IActionResult Index()
        { 
            return View(appContext.Uslugi.ToList().GroupBy(u=>u.ImeUsluga).Select(grp=>grp.First()));
        }

    }
}
