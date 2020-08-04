using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodiumInterview.MortgageApi.Models
{
    public class CreateApplicantModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
