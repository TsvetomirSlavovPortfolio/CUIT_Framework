using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using CUIT_Framework.Config;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CUIT_Framework.Framework
{
    public class Actions : AppContext
    {
        public static void SetText(string text)
        {
            var editControl = new HtmlEdit(browserWindow);
            try
            {
                editControl.SearchProperties[CSVReader.ControlType + ".PropertyNames." + CSVReader.LocatorType] = CSVReader.LocatorValue;
                editControl.WaitForControlEnabled();
                editControl.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find "+CSVReader.ControlType+" Element - Element not Found");
            }
            editControl.Text = text;
        }

        public static void SetTextInTextArea(string text)
        {
            var editControl = new HtmlTextArea(browserWindow);
            try
            {
                editControl.SearchProperties[CSVReader.ControlType + ".PropertyNames." + CSVReader.LocatorType] = CSVReader.LocatorValue;
                editControl.WaitForControlEnabled();
                editControl.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find " + CSVReader.ControlType + " Element - Element not Found");
            }
            editControl.Text = text;
        }

        public static void SelectDropdownByText(string text)
        {
            var dropdownControl = new HtmlComboBox(browserWindow);
            try
            {
                dropdownControl.SearchProperties[CSVReader.ControlType + ".PropertyNames." + CSVReader.LocatorType] = CSVReader.LocatorValue;
                dropdownControl.WaitForControlEnabled();
                dropdownControl.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find " + CSVReader.ControlType + " Element - Element not Found");
            }
            if (!dropdownControl.SelectedItem.Equals(text))
            {
                foreach (var t in dropdownControl.Items.Where(t => t.Name == text))
                {
                    dropdownControl.SelectedItem = text;
                    break;
                }
            }
        }

        public static void SelectDropdownByIndex(int index)
        {
            var dropdownControl = new HtmlComboBox(browserWindow);
            try
            {
                dropdownControl.SearchProperties[CSVReader.ControlType + ".PropertyNames." + CSVReader.LocatorType] = CSVReader.LocatorValue;
                dropdownControl.WaitForControlEnabled();
                dropdownControl.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find " + CSVReader.ControlType + " Element - Element not Found");
            }
            dropdownControl.SelectedIndex = index;
        }

        public static void SelectListItemByText(string option)
        {
            var list = new HtmlList(browserWindow);
            try
            {
                list.SearchProperties.Add(CSVReader.ControlType + ".PropertyNames." + CSVReader.LocatorType, CSVReader.LocatorValue, HtmlList.PropertyNames.Name, "ctl00$contplhDynamic$ddlStatus");
                list.WaitForControlEnabled();
                list.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find " + CSVReader.ControlType + " Element - Element not Found");
            }
            list.DrawHighlight();
            var listItem = new HtmlListItem(list);
            listItem.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            listItem.SearchProperties.Add(HtmlListItem.PropertyNames.InnerText, option, PropertyExpressionOperator.Contains);
            listItem.DrawHighlight();
        }

        public static void SelectCheckbox(bool check)
        {
            var checkboxControl = new HtmlCheckBox(browserWindow);
            try
            {
                checkboxControl.SearchProperties[CSVReader.ControlType + ".PropertyNames." + CSVReader.LocatorType] = CSVReader.LocatorValue;
                checkboxControl.WaitForControlEnabled();
                checkboxControl.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find " + CSVReader.ControlType + " Element - Element not Found");
            }
            checkboxControl.Checked = check;
        }

        public static void SelectRadioButton()
        {
            var radioButtonControl = new HtmlRadioButton(browserWindow);
            try
            {
                radioButtonControl.SearchProperties[CSVReader.ControlType + ".PropertyNames." + CSVReader.LocatorType] = CSVReader.LocatorValue;
                radioButtonControl.WaitForControlEnabled();
                radioButtonControl.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find " + CSVReader.ControlType + " Element - Element not Found");
            }
            radioButtonControl.Selected = true;
        }

        public static void ClickHyperLink()
        {
            var hyperLink = new HtmlHyperlink(browserWindow);
            try
            {
                hyperLink.SearchProperties.Add(CSVReader.ControlType + ".PropertyNames." + CSVReader.LocatorType, CSVReader.LocatorValue);
                hyperLink.WaitForControlEnabled();
                hyperLink.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find " + CSVReader.ControlType + " Element - Element not Found");
            }
            Mouse.Click(hyperLink);
        }

        public static void ClickHyperLinkByText(string name)
        {
            var controlcollection = Elements.GetAllHtmlLinkControls();
            foreach (var s in controlcollection.OfType<HtmlHyperlink>().Where(s => s.InnerText.Equals(name)))
                Mouse.Click(s);
        }


        public static void SendEnter()
        {
            SendKeys.SendWait("{Enter}");
        }
    }

    public class MouseActions : AppContext
    {
        public static void ClickInputButton()
        {
            var btn = new HtmlInputButton(browserWindow) { TechnologyName = "Web" };
            try
            {
                btn.SearchProperties.Add(CSVReader.ControlType+".PropertyNames." + CSVReader.LocatorType, CSVReader.LocatorValue);
                btn.WaitForControlEnabled();
                btn.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find " + CSVReader.ControlType + " Element - Element not Found");
            }
            Mouse.Click(btn);
        }

        public static void ClickButton()
        {
            var btn = new HtmlButton(browserWindow) { TechnologyName = "Web" };
            try
            {
                btn.SearchProperties.Add(CSVReader.ControlType+".PropertyNames." + CSVReader.LocatorType, CSVReader.LocatorValue);
                btn.WaitForControlEnabled();
                btn.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find " + CSVReader.ControlType + " Element - Element not Found");
            }
            Mouse.Click(btn);
        }
    }

    public class Elements: AppContext
    {
        public static bool VerifyDivElementPresent()
        {
            var div = new HtmlDiv(browserWindow);
            try
            {
                div.SearchProperties.Add(CSVReader.ControlType + ".PropertyNames." + CSVReader.LocatorType, CSVReader.LocatorValue);
                div.WaitForControlEnabled(10000);
                div.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find " + CSVReader.ControlType + " Element - Element not Found");
            }
            return div.Enabled;
        }

        public static UITestControlCollection GetAllHtmlLinkControls()
        {
            var link = new HtmlHyperlink(browserWindow);
            link.SearchProperties.Add(CSVReader.ControlType + ".PropertyNames." + CSVReader.LocatorType, CSVReader.LocatorValue);

            var controlCollection = link.FindMatchingControls();
            return controlCollection;
        }

        public static HtmlCell GetHTMLTableControl(string rowIndex, string columnIndex)
        {
            var cell = new HtmlCell(browserWindow);
            try
            {
                cell.SearchProperties.Add(CSVReader.ControlType + ".PropertyNames." + CSVReader.LocatorType, CSVReader.LocatorValue);
                //give the required row and column number
                cell.FilterProperties[HtmlCell.PropertyNames.RowIndex] = rowIndex;
                cell.FilterProperties[HtmlCell.PropertyNames.ColumnIndex] = columnIndex;
                cell.WaitForControlEnabled();
                cell.WaitForControlReady();
            }
            catch (Exception)
            {
                Assert.Fail("Failed to find " + CSVReader.ControlType + " (Table) Element - Element not Found");
            }
            var cellCollection = cell.FindMatchingControls();
            //cast the uitestcontrol to htmlcell
            var desiredcell = (HtmlCell)cellCollection[0];
            return desiredcell;
        }
    }

    public class TableControls : AppContext
    {
        public static void ClickHyperLinkText_TableView(string textLink, string rowIndex, string columnIndex)
        {
            var textControl = Elements.GetHTMLTableControl(rowIndex, columnIndex);
            //to get your desired cell text
            if (textControl.InnerText.Equals(textLink))
            {
                Mouse.Click(textControl);
            }
        }
    }

    public class BrowserActions : AppContext
    {
        public static void KillIeProcesses(string browser)
        {
            try
            {
                var runingProcess = Process.GetProcesses();

                foreach (var t in runingProcess.Where(t => t.ProcessName == browser))
                {
                    // kill  running process
                    t.Kill();
                }
            }
            catch
            {
                //Suppress any exception here
            }
        }
    }
}
