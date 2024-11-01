using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TfLCodingChallengeAutomation;

namespace TfLCodingChallengeAutomation.Hooks

{
    public class Context
    {
        public IWebDriver driver;
        public string baseUrl = "https://tfl.gov.uk/";
        

        public void LaunchTfLApplication()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
        }

        public void TakeScreenshotAtThePointOfTestFailure(string directory, string scenarioName)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string path = directory + scenarioName + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".png";
            string Screenshot = screenshot.AsBase64EncodedString;
            byte[] screenshotAsByteArray = screenshot.AsByteArray;
            screenshot.SaveAsFile(string.Format(path + "{0}.png"));
        }

        public void CloseTFLApplication()
        {
            driver?.Quit();
        }
    }
}