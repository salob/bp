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
    public class SeleniumTests
    {
        // URI for web app being tested
        private String webAppUri;

        [TestInitialize]
        public void Setup()
        {
            //this.webAppUri = "http://localhost:1979";
            //this.webAppUri = "https://sb-csd-bp-staging.azurewebsites.net";
            this.webAppUri = Environment.GetEnvironmentVariable("WEB_APP_URI");
        }

        //method called by all test runs
        public void TestBPUI(string systolic, string diastolic, string category)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless"); // Run Chrome in headless mode
            using (IWebDriver driver = new ChromeDriver(".",options))
            {
                driver.Navigate().GoToUrl(webAppUri);
                // get systolic element
                IWebElement systolicElement = driver.FindElement(By.Id("BP_Systolic"));
                systolicElement.Clear(); //need to remove default systolic first
                systolicElement.SendKeys(systolic);
                // get diastolic element
                IWebElement diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
                diastolicElement.Clear(); //need to remove default diastolic first
                diastolicElement.SendKeys(diastolic);
                // submit the form
                driver.FindElement(By.Id("submitform")).Submit();

                // explictly wait for result with "BMIValue" item
                IWebElement BPCategoryValue = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(c => c.FindElement(By.Id("bpcategory")));
                // Take a screenshot
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                // Save the screenshot to a file
                screenshot.SaveAsFile("../../../TestResults/"+systolic+"over"+diastolic+"screenshot.png");
                // Compre actual category to expected
                String bpcategory = BPCategoryValue.Text.ToString();
                Assert.AreEqual(category, bpcategory);   
                driver.Quit();
            }         
        }

        [TestMethod]
        [DataRow("75", "50","Low Blood Pressure")]
        public void bpLowTest(string systolic, string diastolic, string category)
        {
            TestBPUI(systolic, diastolic, category);
        }

        [TestMethod]
        [DataRow("100", "70","Ideal Blood Pressure")]
        public void bpIdealTest(string systolic, string diastolic, string category)
        {
            TestBPUI(systolic, diastolic, category);
        }
 
        [TestMethod]
        [DataRow("120", "85","Pre-High Blood Pressure")]
        public void bpPreHighTest(string systolic, string diastolic, string category)
        {
            TestBPUI(systolic, diastolic, category);
        }

        [TestMethod]
        [DataRow("130", "90","High Blood Pressure")]
        public void bpHighTest(string systolic, string diastolic, string category)
        {
            TestBPUI(systolic, diastolic, category);
        }               
    }
}