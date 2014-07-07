using System;

namespace CUIT_Framework.ParseData
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DataBindingAttribute : Attribute
    {
        public static readonly Type NativeBinder = typeof(NativeTypeBinder);
        public static readonly Type ListBinder = typeof(ListTypeBinder);
        public static readonly Type DictionaryBinder = typeof(DictionaryTypeBinder);

        public string Key { get; set; }

        public Type Binder { get; set; }

        public string DefaultValue { get; set; }

        public bool IsMandatory { get; set; }

        static DataBindingAttribute()
        {
        }

        public DataBindingAttribute()
            : this(string.Empty, string.Empty)
        {
        }

        public DataBindingAttribute(string key)
            : this(key, DataBindingAttribute.NativeBinder, (string)null)
        {
        }

        public DataBindingAttribute(string key, string defaultValue)
            : this(key, DataBindingAttribute.NativeBinder, defaultValue)
        {
        }

        public DataBindingAttribute(string key, bool isMandatory)
            : this(key, DataBindingAttribute.NativeBinder, isMandatory)
        {
        }

        public DataBindingAttribute(string key, bool isMandatory, string defaultValue)
            : this(key, DataBindingAttribute.NativeBinder, isMandatory, defaultValue)
        {
        }

        public DataBindingAttribute(string key, Type binder, string defaultValue)
            : this(key, binder, true, defaultValue)
        {
        }

        public DataBindingAttribute(string key, Type binder, bool isMandatory)
            : this(key, binder, isMandatory, (string)null)
        {
        }

        public DataBindingAttribute(string key, Type binder, bool isMandatory, string defaultValue)
        {
            this.Key = key;
            this.Binder = binder;
            this.IsMandatory = isMandatory;
            this.DefaultValue = defaultValue;
        }

        public ValueBinder CreateBinder()
        {
            return Activator.CreateInstance(this.Binder) as ValueBinder;
        }
    }
}
