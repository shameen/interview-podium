using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodiumInterview.MortgageApi.Models
{
    public class ApiErrorResult : IApiResponse
    {
        public ApiErrorResult(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public bool Success { get; set; } = false;
        public IEnumerable<string> Errors { get; set; }
    }
}
