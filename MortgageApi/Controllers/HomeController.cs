using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PodiumInterview.MortgageApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : PodiumBaseController
    {
        [HttpGet, Route("")]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
