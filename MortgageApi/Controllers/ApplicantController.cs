using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using PodiumInterview.MortgageApi.Logic;
using PodiumInterview.MortgageApi.Logic.Command;
using PodiumInterview.MortgageApi.Logic.Query;
using PodiumInterview.MortgageApi.Models;
using Swashbuckle.Swagger.Annotations;

namespace PodiumInterview.MortgageApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicantController : PodiumBaseController
    {
        private readonly ILogger<ApplicantController> _logger;
        private readonly IRandomNumberGenerator _idGenerator;
        private readonly ApplicantQuery _applicantQuery;

        public ApplicantController(ILogger<ApplicantController> logger, IRandomNumberGenerator idGenerator,
            ApplicantQuery applicantQuery)
        {
            _logger = logger;
            _idGenerator = idGenerator;
            _applicantQuery = applicantQuery;
        }

        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ApiApplicantCreatedResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ApiErrorResult))]
        public IActionResult SaveApplicantDetails([FromBody]CreateApplicantModel model)
        {
            //Validate
            if (!ModelState.IsValid)
            {
                return ApiValidationError();
            }

            try
            {
                //Save
                var newUserId = _idGenerator.GetRandomLong();
                var saveCommand = new SaveApplicantCommand(model, newUserId);
                saveCommand.Execute();

                //Return
                var fakeResult = new ApiApplicantCreatedResult
                {
                    Success = true,
                    UserId = null
                };
                return Ok(fakeResult);
            }
            catch (Exception ex)
            {
                return ApiServerError(ex.Message);
            }
        }
    }
}
