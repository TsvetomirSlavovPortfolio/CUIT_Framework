using System;
using System.Reflection;

namespace CUIT_Framework.ParseData
{
    public class ListTypeBinder : ValueBinder
    {
        public char Delimiter { get; set; }

        public ListTypeBinder()
        {
            this.Delimiter = '|';
        }

        protected override object Parse(Type type, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (object)null;
            string[] array = value.Split(new char[1]
      {
        this.Delimiter
      }, StringSplitOptions.RemoveEmptyEntries);
            Type elementType = type.GetGenericArguments()[0];
            object list = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod("Add");
            Array.ForEach<string>(array, (Action<string>)(x => method.Invoke(list, new object[1]
      {
        NativeParser.Parse(elementType, x)
      })));
            return list;
        }
    }
}