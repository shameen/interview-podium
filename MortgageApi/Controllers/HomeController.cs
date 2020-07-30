using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PodiumInterview.MortgageApi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
