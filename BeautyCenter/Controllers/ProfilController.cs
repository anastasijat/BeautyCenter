using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyCenter.Models;

namespace BeautyCenter.Controllers
{
    public class ProfilController:Controller
    {
        private db_201920z_va_prj_beauty_centarContext appContext;

        public ProfilController(db_201920z_va_prj_beauty_centarContext context)
        {
            appContext = context;
        }


    }
}
