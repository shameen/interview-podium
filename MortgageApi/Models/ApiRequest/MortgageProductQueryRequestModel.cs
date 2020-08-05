using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PodiumInterview.MortgageApi.Models
{
    public class MortgageProductQueryRequestModel : IValidatableObject
    {
        [Required]
        public decimal PropertyValue { get; set; }
        [Required]
        public decimal DepositAmount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PropertyValue <= 0)
            {
                yield return new ValidationResult("Property Value should be a positive number", new[] { nameof(PropertyValue) });
            }
            if (DepositAmount <= 0)
            {
                yield return new ValidationResult("Deposit Amount should be a positive number", new[] { nameof(DepositAmount) });
            }
            if (DepositAmount > PropertyValue)
            {
                yield return new ValidationResult("Property Value should be higher than the Deposit Amount", new[] { nameof(PropertyValue), nameof(DepositAmount) });
            }
        }
    }
}