using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using TfLCodingChallengeAutomation.Hooks;


namespace TfLCodingChallengeAutomation.Pages
{
    public class JourneyResultPage
    {
        Context context;
        public JourneyResultPage(Context _context)
        {
            context = _context;
        }

        By validationError = By.XPath("//*[@id=\"full-width-content\"]/div/div[8]/div/div/ul/li");
        By updateJourneyBtn = By.XPath("//*[@id=\"more-journey-options\"]/div/fieldset/div[2]/div/input[2]");
        By expectedConfirmationText = By.XPath("//a[@class='earlier jp-ajax-button']");
        By invalidJourneyResult = By.XPath("//div[@class='info-message disambiguation']");
        By clearToLocationField = By.XPath("//a[text()='Clear To location']");
        By homeIcon = By.XPath("//*[@id=\"full-width-content\"]/div/div[1]/nav/ol/li[1]/a/span");
        By routeWithLeastWalkingBtn = By.XPath("//*[@id=\"more-journey-options\"]/div/fieldset/ul[2]/li[1]/fieldset/div/div/div[1]/label[3]");
        By editPreferenceDropdown = By.CssSelector(".toggle-options.more-options");
        By journeyTimes = By.CssSelector("#option-1-heading > div.clearfix.time-boxes.time-boxes-override > div.journey-time.no-map");
        By viewDetails = By.XPath("//*[@id=\"option-1-content\"]/div[1]/div[5]/div[2]/button[1]");
        By accessibilityDetails = By.XPath("//*[@id=\"option-1-accessibility-heading\"]");
        By errorMessage = By.XPath("//*[@id=\"full-width-content\"]/div/div[8]/div/div/div/div/div[2]/div[1]/span");
        public void ClickHomeIcon()
        {
            Thread.Sleep(5000);
            context.driver.Navigate().Refresh();
            context.driver.FindElement(homeIcon).Click();
        }

        public void ClearToField()
        {
            context.driver.FindElement(clearToLocationField).Click();
        }
        
        public void ClickEditPreferencesDropdownButton()
        {
            context.driver.FindElement(editPreferenceDropdown).Click();
        }

        public void ClickOnRouteWithLeastWalkingButton()
        { 
            context.driver.FindElement(routeWithLeastWalkingBtn).Click();
        }
        public void ClickUpdateJourneyButton()
        {
            context.driver.FindElement(updateJourneyBtn).Click();
        }

        public string CheckForConfirmationText()
        {
            return context.driver.FindElement(expectedConfirmationText).Text.Trim();
        }

        public string ValidateJourneyTime()
        {
            return context.driver.FindElement(journeyTimes).Text.Trim();
        }
        public string VerifyVisibilityOfAccessInformation()
        {
            return context.driver.FindElement(accessibilityDetails).Text.Trim();
        }
        public string VerifyValidationError()
        {
            return context.driver.FindElement(validationError).Text.Trim();
        }
    }
}
