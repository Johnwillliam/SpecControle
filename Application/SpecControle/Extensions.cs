namespace SpecControle
{
    public static class Extensions
    {
        public static string EmptyIfNull(this object value)
        {
            return value != null ? value.ToString() : string.Empty;
        }
    }
}
