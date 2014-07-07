using System;
using CUIT_Framework.Config;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CUIT_Framework.Framework
{
    public class Common : AppContext
    {
        public static string Text;
        public static string GetText()
        {
            var textControl = new HtmlControl(browserWindow);
            try
            {
                textControl.SearchProperties.Add(CSVReader.ControlType + ".PropertyNames." + CSVReader.LocatorType, CSVReader.LocatorValue);
                textControl.WaitForControlEnabled();
                textControl.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find HtmlEdit Element - Element not Found");
            }
            return Text = textControl.InnerText;
        }

        public static void FocusOnChildWindow()
        {
            browserWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            foreach (BrowserWindow tempWindow in browserWindow.FindMatchingControls())
            {
                browserWindow = tempWindow;
                browserWindow.SetFocus();
                browserWindow.Maximized = true;
            }
        }
    }
}
