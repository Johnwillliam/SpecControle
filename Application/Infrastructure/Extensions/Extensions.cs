namespace Infrastructure.Extensions
{
    public static class Extensions
    {
        public static string EmptyIfNull(this object value)
        {
            if (value == null)
                return "";
            return value.ToString();
        }

        public static T? GetNullable<T>(this object value) where T : struct
        {
            return value == null || value == DBNull.Value ? (T?)null : (T?)Convert.ChangeType(value, typeof(T));
        }
    }
}
