using Microsoft.VisualStudio.TestTools.UnitTesting;

// NuGet install Selenium WebDriver package and Support Classes
 
using OpenQA.Selenium;

// NuGet install Chrome Driver
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

// run 2 instances of VS to do run Selenium tests against localhost
// instance 1 : run web app e.g. on IIS Express
// instance 2 : from Test Explorer run Selenium test
// or use the dotnet vstest task
// e.g. dotnet vstest BPCalculatorE2ETest\bin\debug\netcoreapp2.1\BPCalculatorE2ETest.dll /Settings:BPCalculatorE2ETest.runsettings

namespace BPCalculatorE2ETest
{
    [TestClass]
    public class BloodPressureFormTests
    {
        // .runsettings file contains test run parameters
        // e.g. URI for app
        // test context for this run

        private TestContext testContextInstance;

        // test harness uses this property to initliase test context
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        // URI for web app being tested
        private String webAppUri;

        // .runsettings property overriden in vsts test runner 
        // release task to point to run settings file
        // also webAppUri overriden to use pipeline variable

        [TestInitialize]                // run before each unit test
        public void Setup()
        {
            //this.webAppUri = "http://localhost:1979";
            this.webAppUri = Environment.GetEnvironmentVariable("WEB_APP_URI");
        }

        [TestMethod]
        public void TestBPUI()
        {

            String chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (chromeDriverPath is null)
            {
                chromeDriverPath = ".";
            }
            
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless"); // Run Chrome in headless mode
            
            using (IWebDriver driver = new ChromeDriver(chromeDriverPath,options))
            {
                
                driver.Navigate().GoToUrl(webAppUri);

                // get systolic element
                IWebElement systolic = driver.FindElement(By.Id("BP_Systolic"));
                // enter 120 in element
                systolic.SendKeys("120");

                // get diastolic element
                IWebElement diastolic = driver.FindElement(By.Id("BP_Diastolic"));
                // enter 80 in element
                diastolic.SendKeys("80");

                // submit the form
                driver.FindElement(By.Id("submitform")).Submit();

                // explictly wait for result with "BMIValue" item
                IWebElement BPCategoryValue = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(c => c.FindElement(By.Id("bpcategory")));

                // Take a screenshot
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                // Save the screenshot to a file
                screenshot.SaveAsFile("../../../TestResults/screenshot.png");

                String bpcategory = BPCategoryValue.Text.ToString();

                StringAssert.Equals(bpcategory, "Pre-High Blood Pressure");
                
                driver.Quit();

            }
        }
    }
}