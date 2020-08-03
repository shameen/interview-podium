using System;

namespace PodiumInterview.Database
{
	public class Applicant : IDatabaseEntity
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}