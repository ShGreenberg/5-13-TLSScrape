using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _5_13_ScrapeLakewoodScoop.web.Models;
using _5_13_ScrapeLakewoodScoop.api;

namespace _5_13_ScrapeLakewoodScoop.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(Api.GetArticles());
        }

      
    }
}
