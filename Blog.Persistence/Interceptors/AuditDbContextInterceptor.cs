using Blog.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Persistence.Interceptors
{
    public class AuditDbContextInterceptor : SaveChangesInterceptor
    {
        private static readonly Dictionary<EntityState, Action<DbContext, BaseEntity>> Behaviors = new()
        {
            { EntityState.Added, AddedBehavior },
            { EntityState.Modified, ModifiedBehavior }
        };

        private static void AddedBehavior(DbContext context, BaseEntity entity)
        {
            context.Entry(entity).Property(e => e.UpdatedDate).IsModified = false;
            entity.CreatedDate = DateTime.Now;
        }
        private static void ModifiedBehavior(DbContext context, BaseEntity entity)
        {
            context.Entry(entity).Property(e => e.CreatedDate).IsModified = false;
            entity.UpdatedDate = DateTime.Now;
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry.Entity is not BaseEntity baseEntity)
                {
                    continue;
                }
                if (entry.State is not EntityState.Added and not EntityState.Modified)
                {
                    continue;
                }
                Behaviors[entry.State](eventData.Context, baseEntity);
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);   
        }
    }
}
