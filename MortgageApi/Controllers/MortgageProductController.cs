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
using Swashbuckle.AspNetCore.Annotations;

namespace PodiumInterview.MortgageApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MortgageProductController : PodiumBaseController
    {
        private readonly ILogger<MortgageProductController> _logger;

        public MortgageProductController(ILogger<MortgageProductController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retrieve Mortgage products for an Applicant
        /// </summary>
        /// <param name="id">Applicant ID</param>
        [HttpPost, Route("{applicantId}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<MortgageProduct>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ApiErrorResult))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ApiErrorResult))]
        public async Task<IActionResult> GetMortgageProductsForApplicant(long applicantId, [FromBody] MortgageProductQueryRequestModel model)
        {
            if (!ModelState.IsValid)
                return ApiValidationError();

            var getApplicantCommand = new GetApplicantQuery(applicantId);
            var applicant = await getApplicantCommand.ExecuteAsync();

            if (applicant == null)
                return ApiValidationError(new [] {"Invalid Applicant ID specified"});

            var getMortgageProductsCommand = new GetMortgageProductsForApplicantQuery(applicant, model.PropertyValue, model.DepositAmount);
            var mortgageProducts = await getMortgageProductsCommand.ExecuteAsync();

            return Ok(mortgageProducts);
        }
    }
}
