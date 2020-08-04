using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PodiumInterview.MortgageApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace PodiumInterview.MortgageApi.Controllers
{
    public abstract class PodiumBaseController : ControllerBase
    {
        /// <summary>
        /// Returns a "400 Bad Request" API error,
        /// including any <see cref="ModelStateDictionary">ModelState</see> errors.
        /// </summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ApiErrorResult))]
        internal IActionResult ApiValidationError(IEnumerable<string> extraErrors = null)
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

        /// <summary>
        /// Returns a "500 Internal Server Error" API error.
        /// </summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(ApiErrorResult))]
        internal IActionResult ApiServerError(object additionalInfo = null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, additionalInfo);
        }
    }
}
