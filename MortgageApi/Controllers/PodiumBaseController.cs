using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PodiumInterview.MortgageApi.Models;
using Swashbuckle.Swagger.Annotations;

namespace PodiumInterview.MortgageApi.Controllers
{
    public abstract class PodiumBaseController : ControllerBase
    {
        /// <summary>
        /// Returns an API BadRequest error, including any <see cref="ModelStateDictionary">ModelState</see> errors.
        /// </summary>
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(ApiErrorResult))]
        public IActionResult ApiValidationError(IEnumerable<string> extraErrors = null)
        {
            //Construct errors from ModelState
            var errors = ModelState
                .Where(m => m.Value.Errors.Any())
                .Select(m =>
                    m.Key+" : "+string.Join(",",m.Value.Errors.Select(e => e.ErrorMessage))
                );
            //Add additional errors if any
            if (extraErrors != null)
                errors = extraErrors.Concat(errors);
            return BadRequest(new ApiErrorResult(errors));
        }

        public IActionResult ApiServerError(object additionalInfo = null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, additionalInfo);
        }
    }
}
