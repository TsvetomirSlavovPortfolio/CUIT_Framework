using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace CUIT_Framework.ParseData
{
    public class TestRunner
    {
        public static void Execute<T>(Action<T> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2>(Action<T1, T2> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3>(Action<T1, T2, T3> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action, DataRow row)
        {
            TestRunner.ExecuteDelegate((Delegate)action, row);
        }

        public static void ExecuteDelegate(Delegate dlg, DataRow row)
        {
            object[] objArray = Enumerable.ToArray<object>(Enumerable.Select<Tuple<ParameterInfo, DataBindingAttribute>, object>((IEnumerable<Tuple<ParameterInfo, DataBindingAttribute>>)Enumerable.ToList<Tuple<ParameterInfo, DataBindingAttribute>>(Enumerable.Select<ParameterInfo, Tuple<ParameterInfo, DataBindingAttribute>>((IEnumerable<ParameterInfo>)dlg.Method.GetParameters(), (Func<ParameterInfo, Tuple<ParameterInfo, DataBindingAttribute>>)(p => new Tuple<ParameterInfo, DataBindingAttribute>(p, Enumerable.Single<DataBindingAttribute>(Enumerable.Cast<DataBindingAttribute>((IEnumerable)p.GetCustomAttributes(typeof(DataBindingAttribute), false))))))), (Func<Tuple<ParameterInfo, DataBindingAttribute>, object>)(p =>
            {
                string local_0 = p.Item2.Key ?? p.Item1.Name;
                return p.Item2.CreateBinder().GetValue(p.Item1.ParameterType, row[local_0], p.Item2.DefaultValue);
            })));
            dlg.DynamicInvoke(objArray);
        }
    }
}
