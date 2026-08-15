using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;

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

        // SET IDENTITY_INSERT does not accept parameterized object names, so ExecuteSql cannot be used here.
        // Schema/table come from EF's own model metadata and value is restricted to "ON"/"OFF" above, not user input.
        [SuppressMessage("Microsoft.EntityFrameworkCore", "EF1002", Justification = "No user input; schema/table come from EF model metadata and value is a fixed \"ON\"/\"OFF\" literal.")]
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
            context.DisableIdentityInsert<T>();
            transaction.Commit();
        }
    }
}