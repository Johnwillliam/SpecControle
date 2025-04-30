namespace Application.Business
{
    public static class CellValidation
    {
        public static bool ValidateNumber(string value, Type type)
        {
            return (IsDecimalNumber(type) && !double.TryParse(value, out _)) ||
                        (!IsDecimalNumber(type) && IsNumericType(type) && !value.All(char.IsDigit));
        }

        public static bool CheckValue(string value, Type type)
        {
            //always check non nullable properties, check value if not empty
            return !IsNullable(type) || !string.IsNullOrEmpty(value);
        }

        public static bool IsNullable(Type type)
        {
            if (!type.IsValueType) return true; // ref-type
            if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
            return false; // value-type
        }

        public static bool IsDecimalNumber(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return IsDecimalNumber(Nullable.GetUnderlyingType(type));
            }

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Decimal:
                case TypeCode.Double:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsNumericType(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return IsNumericType(Nullable.GetUnderlyingType(type));
            }

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;

                default:
                    return false;
            }
        }
    }
}
