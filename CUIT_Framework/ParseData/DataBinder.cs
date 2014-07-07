using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace CUIT_Framework.ParseData
{
    public class DataBinder
    {
        public static T Bind<T>(DataRow dataSource)
        {
            T instance = Activator.CreateInstance<T>();
            DataBinder.Bind((object)instance, dataSource);
            return instance;
        }

        public static void Bind(object bindTo, DataRow dataSource)
        {
            List<KeyValuePair<PropertyInfo, DataBindingAttribute>> list1 = Enumerable.ToList<KeyValuePair<PropertyInfo, DataBindingAttribute>>(Enumerable.Select<PropertyInfo, KeyValuePair<PropertyInfo, DataBindingAttribute>>((IEnumerable<PropertyInfo>)bindTo.GetType().GetProperties(), (Func<PropertyInfo, KeyValuePair<PropertyInfo, DataBindingAttribute>>)(x => new KeyValuePair<PropertyInfo, DataBindingAttribute>(x, Enumerable.SingleOrDefault<DataBindingAttribute>(Enumerable.Cast<DataBindingAttribute>((IEnumerable)x.GetCustomAttributes(typeof(DataBindingAttribute), false)))))));
            List<KeyValuePair<FieldInfo, DataBindingAttribute>> list2 = Enumerable.ToList<KeyValuePair<FieldInfo, DataBindingAttribute>>(Enumerable.Select<FieldInfo, KeyValuePair<FieldInfo, DataBindingAttribute>>((IEnumerable<FieldInfo>)bindTo.GetType().GetFields(), (Func<FieldInfo, KeyValuePair<FieldInfo, DataBindingAttribute>>)(x => new KeyValuePair<FieldInfo, DataBindingAttribute>(x, Enumerable.SingleOrDefault<DataBindingAttribute>(Enumerable.Cast<DataBindingAttribute>((IEnumerable)x.GetCustomAttributes(typeof(DataBindingAttribute), false)))))));
            list1.ForEach((Action<KeyValuePair<PropertyInfo, DataBindingAttribute>>)(x =>
            {
                string local_0 = x.Value == null ? x.Key.Name : x.Value.Key;
                if (x.Value == null)
                    return;
                try
                {
                    x.Value.CreateBinder().BindValue(bindTo, x.Key, dataSource[local_0], x.Value.DefaultValue);
                }
                catch (ArgumentException exception_0)
                {
                    if (!x.Value.IsMandatory)
                        x.Value.CreateBinder().BindValue(bindTo, x.Key, !string.IsNullOrEmpty(x.Value.DefaultValue) ? (object)x.Value.DefaultValue : (object)(string)null, x.Value.DefaultValue);
                    else
                        throw;
                }
            }));
            list2.ForEach((Action<KeyValuePair<FieldInfo, DataBindingAttribute>>)(x =>
            {
                string local_0 = x.Value == null ? x.Key.Name : x.Value.Key;
                if (x.Value == null)
                    return;
                try
                {
                    x.Value.CreateBinder().BindValue(bindTo, x.Key, dataSource[local_0], x.Value.DefaultValue);
                }
                catch (ArgumentException exception_1)
                {
                    if (!x.Value.IsMandatory)
                        x.Value.CreateBinder().BindValue(bindTo, x.Key, !string.IsNullOrEmpty(x.Value.DefaultValue) ? (object)x.Value.DefaultValue : (object)(string)null, x.Value.DefaultValue);
                    else
                        throw;
                }
            }));
        }
    }
}
