using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TfLCodingChallengeAutomation.Hooks;

namespace TfLCodingChallengeAutomation.Pages
{
    public class Homepage
    {
        Context context;
        public Homepage(Context _context)
        {
            context = _context;
        }

        By fromTextField = By.CssSelector(".jpFrom.tt-input");
        By toTextField = By.CssSelector(".jpTo.tt-input");
        By planMyJourneyBtn = By.XPath("//*[@id=\"plan-journey-button\"]");
        By fromError = By.XPath("//*[@id=\"InputFrom-error\"]");
        By location1Suggestions = By.XPath("//*[@id=\"stop-points-search-suggestion-0\"]");
        By location2Suggestions = By.XPath("//*[@id=\"stop-points-search-suggestion-5\"]");
        By acceptCookies = By.XPath("//strong[text()='Accept all cookies']");
        public void SelectFromLocationDropdown()
        {
            context.driver.FindElement(location1Suggestions).Click();
        }
        public void AcceptAllCookies()
        {
            context.driver.FindElement(acceptCookies).Click();
        }

        public void SelectToLocationDropdown()
        {
            context.driver.FindElement(location2Suggestions).Click();
        }
        public void InputsIntoTheFromTextField(string from)
        {
            context.driver.FindElement(fromTextField).Clear();
            context.driver.FindElement(fromTextField).SendKeys(from);
        }

        public void InputsIntoTheToField(string to)
        {
            context.driver.FindElement(toTextField).Clear();
            context.driver.FindElement(toTextField).SendKeys(to);
        }

        public JourneyResultPage ClickPlanMyJourneyButton()
        {
            context.driver.FindElement(planMyJourneyBtn).Click();
            return new JourneyResultPage(context);
        }

        public string VerifyFromErrorMessage()
        {
            return context.driver.FindElement(fromError).Text.Trim();
        }
    }
}
