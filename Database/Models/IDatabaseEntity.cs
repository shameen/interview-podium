using System;

namespace PodiumInterview.Database
{
    public interface IDatabaseEntity
    {
        long Id { get; set; }
        DateTimeOffset CreationDate { get; set; }
    }
}