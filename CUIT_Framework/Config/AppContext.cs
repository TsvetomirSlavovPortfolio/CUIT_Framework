using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CUIT_Framework.Config
{
    public class AppContext
    {
        protected static BrowserWindow browserWindow;

        public TestContext TestContext { get; set; }
    }
}
