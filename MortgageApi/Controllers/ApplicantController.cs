using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using PodiumInterview.Database;
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

        [HttpPost, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ApiApplicantCreatedResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ApiErrorResult))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(ApiErrorResult))]
        public IActionResult SaveApplicantDetails([FromBody]CreateApplicantModel model)
        {
            //Validate
            if (!ModelState.IsValid)
            {
                return ApiValidationError();
            }

            try
            {
                //Save to DB
                var newUserId = _idGenerator.GetRandomLong();
                var saveCommand = new SaveApplicantCommand(model, newUserId);
                saveCommand.Execute();

                //Return
                var result = new ApiApplicantCreatedResult
                {
                    Success = true,
                    UserId = newUserId
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ApiServerError(ex.Message);
            }
        }

        [HttpPost, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Applicant))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ApiErrorResult))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(ApiErrorResult))]
        public IActionResult GetApplicantDetails(long id)
        {
            var applicant = _applicantQuery.GetApplicant(id);

            if (applicant == null)
                return ApiValidationError(new [] {"Invalid Applicant ID specified"});

            return Ok();
        }
    }
}
