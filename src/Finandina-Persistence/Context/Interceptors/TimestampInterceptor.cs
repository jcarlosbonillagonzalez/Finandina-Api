using Finandina_Domain.Common;
using Finandina_Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Finandina_Persistence.Context.Interceptors
{
    public sealed class TimestampInterceptor : SaveChangesInterceptor
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ICurrentUser _currentUser;
        private readonly ICurrentTenantProvider _tenantProvider;

        public TimestampInterceptor(IDateTimeProvider dateTimeProvider,
                                    ICurrentUser currentUser,
                                    ICurrentTenantProvider tenantProvider)
        {
            _dateTimeProvider = dateTimeProvider;
            _currentUser = currentUser;
            _tenantProvider = tenantProvider;
        }

        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            if (eventData.Context is { } ctx) ApplyTimestamps(ctx);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is { } ctx) ApplyTimestamps(ctx);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void ApplyTimestamps(DbContext context)
        {
            var now = _dateTimeProvider.NowUtc;
            var tenantId = _tenantProvider.TenantId
                        ?? throw new InvalidOperationException("Tenant missing");

            foreach (var entry in context.ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = now;
                        entry.Entity.ModifiedAt = now;
                        entry.Entity.CreatedBy = _currentUser.UserId;
                        entry.Entity.TenantId = tenantId;
                        break;

                    case EntityState.Modified:
                        if (entry.Properties.Any(p => p.IsModified))
                        {
                            entry.Entity.ModifiedAt = now;
                            entry.Entity.ModifiedBy = _currentUser.UserId;
                        }
                        break;
                }
            }
        }
    }
}
