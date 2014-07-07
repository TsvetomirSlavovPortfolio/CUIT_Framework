using System;
using System.Reflection;

namespace CUIT_Framework.ParseData
{
    public class DictionaryTypeBinder : ValueBinder
    {
        public char Delimiter { get; set; }

        public char Separator { get; set; }

        public DictionaryTypeBinder()
        {
            this.Delimiter = '|';
            this.Separator = ':';
        }

        protected override object Parse(Type type, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (object)null;
            string[] strArray = value.Split(new char[1]
      {
        this.Delimiter
      }, StringSplitOptions.RemoveEmptyEntries);
            Type elementType = type.GetGenericArguments()[0];
            object instance = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod("Add");
            foreach (string str1 in strArray)
            {
                string str2 = str1.Split(new char[1]
        {
          this.Separator
        })[0];
                string str3 = str1.Split(new char[1]
        {
          this.Separator
        })[1];
                method.Invoke(instance, new object[2]
        {
          NativeParser.Parse(elementType, str2),
          NativeParser.Parse(elementType, str3)
        });
            }
            return instance;
        }
    }
}
