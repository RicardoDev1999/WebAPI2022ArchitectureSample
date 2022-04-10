using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAPI2022ArchitectureTest.Application.Common.Interfaces;
using WebAPI2022ArchitectureTest.Domain.Models;
using WebAPI2022ArchitectureTest.Infrastructure.Identity;

namespace WebAPI2022ArchitectureTest.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            //{
            //    switch (entry.State)
            //    {
            //        case EntityState.Added:
            //            entry.Entity.CreatedBy = _currentUserService.UserId;
            //            entry.Entity.Created = _dateTime.Now;
            //            break;

            //        case EntityState.Modified:
            //            entry.Entity.LastModifiedBy = _currentUserService.UserId;
            //            entry.Entity.LastModified = _dateTime.Now;
            //            break;
            //    }
            //}

            //var events = ChangeTracker.Entries<IHasDomainEvent>()
            //        .Select(x => x.Entity.DomainEvents)
            //        .SelectMany(x => x)
            //        .Where(domainEvent => !domainEvent.IsPublished)
            //        .ToArray();

            var result = await base.SaveChangesAsync(cancellationToken);

            //await DispatchEvents(events);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
