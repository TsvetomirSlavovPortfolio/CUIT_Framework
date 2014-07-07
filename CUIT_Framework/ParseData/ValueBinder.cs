using System;
using System.Reflection;

namespace CUIT_Framework.ParseData
{
    public abstract class ValueBinder
    {
        public object GetValue(Type type, object bindingValue, string defaultValue)
        {
            string str = (bindingValue == null || bindingValue == DBNull.Value ? (string)null : bindingValue.ToString()) ?? defaultValue;
            return this.Parse(type, str);
        }

        public void BindValue(object target, PropertyInfo property, object bindingValue, string defaultValue)
        {
            string str = (bindingValue == null || bindingValue == DBNull.Value ? (string)null : bindingValue.ToString()) ?? defaultValue;
            property.SetValue(target, this.Parse(property.PropertyType, str), (object[])null);
        }

        public void BindValue(object target, FieldInfo field, object bindingValue, string defaultValue)
        {
            string str = (bindingValue == null || bindingValue == DBNull.Value ? (string)null : bindingValue.ToString()) ?? defaultValue;
            field.SetValue(target, this.Parse(field.FieldType, str));
        }

        protected abstract object Parse(Type type, string value);
    }
}
