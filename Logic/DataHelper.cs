using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;

namespace Logic
{
    public static class DataHelper
    {
        public static int? ToNullableInt(this string s)
        {
            if (int.TryParse(s, out int i)) return i;
            return null;
        }

        public static decimal? ToNullableDecimal(this string s)
        {
            if (decimal.TryParse(s, out decimal i)) return i;
            return null;
        }

        public static T ToObject<T>(this DataRow dataRow)
        where T : new()
        {
            T item = new T();

            foreach (DataColumn column in dataRow.Table.Columns)
            {
                PropertyInfo property = GetProperty(typeof(T), column.ColumnName);

                if (property != null && dataRow[column] != DBNull.Value && dataRow[column].ToString() != "NULL")
                {
                    property.SetValue(item, ChangeType(dataRow[column], property.PropertyType), null);
                }
            }

            return item;
        }

        private static PropertyInfo GetProperty(Type type, string attributeName)
        {
            PropertyInfo property = type.GetProperty(attributeName);

            if (property != null)
            {
                return property;
            }

            return type.GetProperties()
                 .FirstOrDefault(p => p.IsDefined(typeof(DisplayAttribute), false) && p.GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>().Single().Name == attributeName);
        }

        public static object ChangeType(object value, Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                return Convert.ChangeType(value, Nullable.GetUnderlyingType(type));
            }

            return Convert.ChangeType(value, type);
        }

        public static string CreateHighLowText(string highText, string lowText)
        {
            if (!string.IsNullOrEmpty(highText) && !string.IsNullOrEmpty(lowText))
                return $"{highText} / {lowText}";
            else if (!string.IsNullOrEmpty(highText))
                return $"{highText}";
            else if (!string.IsNullOrEmpty(lowText))
                return $"{lowText}";

            return "";
        }

        public static string NullableBooleanToYesNo(bool? value) => value.HasValue && value.Value ? "Yes" : "No";
    }
}