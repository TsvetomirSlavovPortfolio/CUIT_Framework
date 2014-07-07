using System;

namespace CUIT_Framework.ParseData
{
    internal delegate bool Parser<T>(string value, out T target);

    internal class NativeParser
    {
        public static object Parse<T>(string value, T defaultValue, Parser<T> parseValue)
        {
            T target = default(T);
            if (parseValue(value, out target))
                return (object)target;
            else
                return (object)defaultValue;
        }

        internal static object Parse(Type elementType, string value)
        {
            switch (Type.GetTypeCode(elementType))
            {
                case TypeCode.Boolean:
                    return NativeParser.Parse<bool>(value, false, new Parser<bool>(bool.TryParse));
                case TypeCode.Char:
                    return NativeParser.Parse<char>(value, ' ', new Parser<char>(char.TryParse));
                case TypeCode.SByte:
                    return NativeParser.Parse<sbyte>(value, sbyte.MinValue, new Parser<sbyte>(sbyte.TryParse));
                case TypeCode.Byte:
                    return NativeParser.Parse<byte>(value, (byte)0, new Parser<byte>(byte.TryParse));
                case TypeCode.Int16:
                    return NativeParser.Parse<short>(value, (short)0, new Parser<short>(short.TryParse));
                case TypeCode.UInt16:
                    return NativeParser.Parse<ushort>(value, (ushort)0, new Parser<ushort>(ushort.TryParse));
                case TypeCode.Int32:
                    return NativeParser.Parse<int>(value, 0, new Parser<int>(int.TryParse));
                case TypeCode.UInt32:
                    return NativeParser.Parse<uint>(value, 0U, new Parser<uint>(uint.TryParse));
                case TypeCode.Int64:
                    return NativeParser.Parse<long>(value, 0L, new Parser<long>(long.TryParse));
                case TypeCode.UInt64:
                    return NativeParser.Parse<ulong>(value, 0UL, new Parser<ulong>(ulong.TryParse));
                case TypeCode.Single:
                    return NativeParser.Parse<float>(value, 0.0f, new Parser<float>(float.TryParse));
                case TypeCode.Double:
                    return NativeParser.Parse<double>(value, 0.0, new Parser<double>(double.TryParse));
                case TypeCode.Decimal:
                    return NativeParser.Parse<Decimal>(value, new Decimal(0, 0, 0, false, (byte)1), new Parser<Decimal>(Decimal.TryParse));
                case TypeCode.DateTime:
                    return NativeParser.Parse<DateTime>(value, DateTime.MinValue, new Parser<DateTime>(DateTime.TryParse));
                case TypeCode.String:
                    return (object)value;
                default:
                    throw new NotSupportedException("Unsupported type code.");
            }
        }
    }
}
