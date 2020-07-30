using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PodiumInterview.MortgageApi.Models;

namespace PodiumInterview.MortgageApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly ILogger<ApplicantController> _logger;
        public ApplicantController(ILogger<ApplicantController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SaveApplicantDetails([FromBody]CreateApplicantModel model)
        {
            //TODO: Save to database

            var fakeResult = new CreateApplicantResult
            {
                Success = true,
                UserId = null
            };

            return Ok(fakeResult);
        }
    }
}
