using System;

namespace PodiumInterview.Database
{
	public class MortgageProduct : IDatabaseEntity
	{
		public long Id { get; set; }
		public long LenderId { get; set; }
		public decimal InterestRate { get; set; }
		public DateTime CreationDate { get; set; }
	}
}