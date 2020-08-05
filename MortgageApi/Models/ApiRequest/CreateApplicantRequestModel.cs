using PodiumInterview.MortgageApi.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PodiumInterview.MortgageApi.Models
{
    public class CreateApplicantRequestModel : IValidatableObject
    {
        [Required, StringLength(255, MinimumLength = 3)]
        public string Email { get; set; }
        [StringLength(200)]
        public string FirstName { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            const int SQL_SERVER_DATETIME_MINIMUM_SAFE_YEAR = 1753;
            if (DateOfBirth.Year < SQL_SERVER_DATETIME_MINIMUM_SAFE_YEAR)
            {
                yield return new ValidationResult("Please enter a valid Date of Birth", new[] { nameof(DateOfBirth) });
            }
            if ((FirstName + LastName).Length < 2)
            {
                yield return new ValidationResult("Please enter at least a First or Last Name.", new[] { nameof(FirstName), nameof(LastName) });
            }
            if (!EmailValidator.IsEmailValid(Email))
            {
                yield return new ValidationResult("Please enter a valid Email address", new[] { nameof(Email) });
            }
        }
    }
}
