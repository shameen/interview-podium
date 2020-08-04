using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PodiumInterview.Database
{
	public class MortgageProduct : IDatabaseEntity
	{
		public long Id { get; set; }
		public long LenderId { get; set; }
		public decimal InterestRate { get; set; }
		public InterestRateType InterestRateType { get; set; }
		public decimal? MaximumLoanToValue { get; set; }
		public DateTimeOffset CreationDate { get; set; }

		[ForeignKey("LenderId")]
		public virtual Lender Lender { get; set; }
	}
}