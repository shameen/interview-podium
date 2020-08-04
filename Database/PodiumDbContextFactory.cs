using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodiumInterview.Database
{
    public static class PodiumDbContextFactory
    {
        /// <summary>
        /// Because the Database is currently in-memory, 
        /// we need to do a bit of extra work before accessing the EF DbContext.
        /// </summary>
        /// <returns></returns>
        public static IPodiumDatabaseContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<PodiumDbContext>()
               .UseInMemoryDatabase(databaseName: "PodiumInterview")
               .Options;

            var dbContext = new PodiumDbContext(options);

            new DataSeeder(dbContext).Seed();

            return dbContext;
        }
    }
}
