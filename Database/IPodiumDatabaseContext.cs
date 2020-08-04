using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;

namespace PodiumInterview.Database
{
    public interface IPodiumDatabaseContext : IDbContext
    {
        DbSet<Applicant> Applicants { get; set; }
        DbSet<Lender> Lenders { get; set; }
        DbSet<MortgageProduct> MortgageProducts { get; set; }
    }

    /// <summary>
    /// <see cref="DbContext"/> does not have a direct interface, so this is a wrapper
    /// </summary>
    public interface IDbContext : IDisposable, IAsyncDisposable, IInfrastructure<IServiceProvider>, IDbContextDependencies, IDbSetCache, IDbContextPoolable, IResettableService
    {
        ChangeTracker ChangeTracker { get; }
        DatabaseFacade Database { get; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}