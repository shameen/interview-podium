using System;

namespace PodiumInterview.Database
{
    public class Lender : IDatabaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}