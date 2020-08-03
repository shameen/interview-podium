using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PodiumInterview.Database;

namespace PodiumInterview.MortgageApi.Logic.Query
{
    public class ApplicantQuery
    {
        private readonly IPodiumDatabaseContext _dbContext;
        public ApplicantQuery(IPodiumDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Database.Applicant GetApplicant(long id)
        {
            return _dbContext.Applicants.SingleOrDefault(a => a.Id == id);
        }
    }
}
