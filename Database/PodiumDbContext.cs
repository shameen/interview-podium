using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PodiumInterview.Database
{
    public class PodiumDbContext : DbContext, IPodiumDatabaseContext
    {
        public PodiumDbContext() : base()
        {
            //Re-create Database every time + Seed
            Database.EnsureDeleted();
            Database.EnsureCreated();
            new DataSeeder(this).Seed();
        }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Lender> Lenders { get; set; }
        public virtual DbSet<MortgageProduct> MortgageProducts { get; set; }
    }
}
