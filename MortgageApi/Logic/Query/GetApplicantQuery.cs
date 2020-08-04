using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PodiumInterview.Database;

namespace PodiumInterview.MortgageApi.Logic.Query
{
    public class GetApplicantQuery : IQuery<Applicant>
    {
        private readonly long _applicantId;

        public GetApplicantQuery(long applicantId)
        {
            _applicantId = applicantId;
        }

        public async Task<Applicant> ExecuteAsync()
        {
            using (var db = PodiumDbContextFactory.GetDbContext())
            {
                return await db.Applicants.SingleOrDefaultAsync(a => a.Id == _applicantId);
            }
        }
    }
}
