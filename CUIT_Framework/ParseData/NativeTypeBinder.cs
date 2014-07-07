using System;

namespace CUIT_Framework.ParseData
{
    public class NativeTypeBinder : ValueBinder
    {
        protected override object Parse(Type type, string value)
        {
            return NativeParser.Parse(type, value);
        }
    }
}
