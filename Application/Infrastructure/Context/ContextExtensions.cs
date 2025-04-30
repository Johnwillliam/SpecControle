using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using Infrastructure.Context;

namespace Infrastructure.Context
{
    public static class ContextExtensions
    {
        public static void EnableIdentityInsert<T>(this SpecificationsDatabaseModel context) => SetIdentityInsert<T>(context, true);

        public static void DisableIdentityInsert<T>(this SpecificationsDatabaseModel context) => SetIdentityInsert<T>(context, false);

        private static void SetIdentityInsert<T>([NotNull] SpecificationsDatabaseModel context, bool enable)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            var entityType = context.Model.FindEntityType(typeof(T));
            var value = enable ? "ON" : "OFF";
            ExecuteSqlRaw(context, entityType, value);
        }

        private static void ExecuteSqlRaw(SpecificationsDatabaseModel context, IEntityType entityType, string value)
        {
            context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {entityType?.GetSchema()}.{entityType?.GetTableName()} {value}");
        }

        public static void SaveChangesWithIdentityInsert<T>([NotNull] this SpecificationsDatabaseModel context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            SaveChanges<T>(context);
        }

        private static void SaveChanges<T>(SpecificationsDatabaseModel context)
        {
            using var transaction = context.Database.BeginTransaction();
            context.EnableIdentityInsert<T>();
            context.SaveChanges();
            context.EnableIdentityInsert<T>();
            transaction.Commit();
        }
    }
}
