using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JovemProgramadorMVC2.Controllers
{
    public class ConhecimentosController : Controller
    {
        public ConhecimentosController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
