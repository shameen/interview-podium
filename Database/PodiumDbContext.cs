using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PodiumInterview.Database
{
    public class PodiumDbContext : DbContext, IPodiumDatabaseContext
    {
        public PodiumDbContext(DbContextOptions<PodiumDbContext> options) : base(options) { }

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Lender> Lenders { get; set; }
        public virtual DbSet<MortgageProduct> MortgageProducts { get; set; }
    }
}
