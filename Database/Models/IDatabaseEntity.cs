using System;

namespace PodiumInterview.Database
{
    public interface IDatabaseEntity
    {
        long Id { get; set; }
        DateTime CreationDate { get; set; }
    }
}