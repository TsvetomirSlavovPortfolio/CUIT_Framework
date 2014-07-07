using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CUIT_Framework.ParseData
{
    public class BaseFixture
    {
        private static readonly string RunId = DateTime.Now.ToString("yyyy.MM.dd.hh.mm.") + Guid.NewGuid().ToString();
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return this.testContextInstance;
            }
            set
            {
                this.testContextInstance = value;
            }
        }

        public object this[string key]
        {
            get
            {
                return this.TestContext.DataRow[key];
            }
        }

        static BaseFixture()
        {
        }

        [ClassInitialize]
        public static string GetRunId()
        {
            return BaseFixture.RunId;
        }

        public T GetValue<T>(string key, T defaultValue)
        {
            object obj = this[key];
            if (obj == null || !(obj is T))
                return defaultValue;
            else
                return (T)obj;
        }
    }
}
