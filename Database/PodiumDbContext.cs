using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PodiumInterview.Database
{
    public class PodiumDbContext : DbContext, IPodiumDatabaseContext
    {
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Lender> Lenders { get; set; }
        public virtual DbSet<MortgageProduct> MortgageProducts { get; set; }
    }

    public interface IPodiumDatabaseContext
    {
        DbSet<Applicant> Applicants { get; set; }
        DbSet<Lender> Lenders { get; set; }
        DbSet<MortgageProduct> MortgageProducts { get; set; }
    }
}
