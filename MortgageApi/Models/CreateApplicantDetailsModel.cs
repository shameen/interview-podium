using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodiumInterview.MortgageApi.Models
{
    public class CreateApplicantModel
    {
        private string Email { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private DateTime DateOfBirth { get; set; }
    }
}
