using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace App.Repositories.Interceptors
{
    public class AuditDbContextInterceptor : SaveChangesInterceptor
    {
        private static readonly Dictionary<EntityState, Action<DbContext, IAuditEntity>> Behaviors = new()
        {

            {EntityState.Added,AddBehavior},
            {EntityState.Modified,ModifiedBehavior}

        };
        private static void AddBehavior(DbContext context, IAuditEntity auditEntity)
        {

            auditEntity.Created = DateTime.Now;
            context.Entry(auditEntity).Property(x => x.Updated).IsModified = false;
        }
        private static void ModifiedBehavior(DbContext context, IAuditEntity auditEntity)
        {
            auditEntity.Updated = DateTime.Now;
            context.Entry(auditEntity).Property(x => x.Created).IsModified = false;
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {

            foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries())
            {
                if (entityEntry.Entity is not IAuditEntity auiditEntity) continue;
                Behaviors[entityEntry.State](eventData.Context, auiditEntity);


                #region 1.way
                //switch (entityEntry.State)
                //{
                //    case EntityState.Added:
                //        AddBehavior(eventData.Context, auiditEntity);
                //        break;
                //    case EntityState.Modified:
                //        ModifiedBehavior(eventData.Context, auiditEntity);
                //        break;
                //}
                #endregion
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        }









    }

}
