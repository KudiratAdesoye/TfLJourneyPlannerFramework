using System;
using System.IO;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using TfLCodingChallengeAutomation.Pages;
using TfLCodingChallengeAutomation.Hooks;
using NUnit.Framework;
using System.Threading;
using TfLCodingChallengeAutomation.Pages;
using static OpenQA.Selenium.BiDi.Modules.Input.Pointer;

namespace TfLCodingChallengeAutomation.StepDefinition
{
    [Binding]
    public class JourneyPlannerSteps
    {
     Homepage homepage;
     Context context;
     JourneyResultPage journeyResultPage;
     ScenarioContext scenarioContext;
     static ExtentTest feature;
     static ExtentTest scenario;
     static ExtentReports report;
     string expectedResult = "";
     string expectedErrorMessage = "";
     string expectedJourneyTimes = "";
     string expectedConfirmationText = "";
     public JourneyPlannerSteps(Homepage _homepage, Context _context,
               JourneyResultPage _journeyResultPage, ScenarioContext _scenarioContext)
     {
        homepage = _homepage;
        context = _context;
        journeyResultPage = _journeyResultPage;
        scenarioContext = _scenarioContext;
     }

     [Given(@"that TfL website is loaded")]
     public void GivenThatTfLWebsiteIsLoaded()
     {
            context.LaunchTfLApplication();
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }
   
    [When(@"a user inputs '([^']*)' into the From text field")]
    public void WhenAUserInputsIntoTheFromTextField(string leic)
        {
            homepage.InputsIntoTheFromTextField(leic);
        }
        [When(@"a user clicks on the Accept all cookies button")]
        public void WhenAUserClicksOnTheAcceptAllCookiesButton()
        {
            homepage.AcceptAllCookies();
        }


        [When(@"a user clicks on '([^']*)' from the list suggested for From field")]
    public void WhenAUserClicksOnFromTheListSuggestedForFromField(string p0)
    {
            homepage.SelectFromLocationDropdown();
        }

    [When(@"a user inputs '([^']*)' into the To text field")]
    public void WhenAUserInputsIntoTheToTextField(string cove)
    {
            homepage.InputsIntoTheToField(cove);
        }

    [When(@"a user clicks on '([^']*)' from the list suggested for To field")]
    public void WhenAUserClicksOnFromTheListSuggestedForToField(string p0)
    {
            homepage.SelectToLocationDropdown();
        }

     [When(@"a user clicks on plan my journey button")]
     public void WhenAUserClicksOnPlanMyJourneyButton()
     {
            homepage.ClickPlanMyJourneyButton();
        }

        [Then(@"a journey result page showing '([^']*)' must be displayed")]
        public void ThenAJourneyResultPageShowingMustBeDisplayed(string p0)
        {
            string actualResult = journeyResultPage.CheckForConfirmationText();
            Assert.That(actualResult.Contains(expectedResult));
        }

     [When(@"a user clicks the Edit preferences dropdown button")]
     public void WhenAUserClicksTheEditPreferencesDropdownButton()
        {

            journeyResultPage.ClickEditPreferencesDropdownButton();
        }

     [When(@"a user clicks the Routes with least walking button")]
     public void WhenAUserClicksTheRoutesWithLeastWalkingButton()
        {
            journeyResultPage.ClickOnRouteWithLeastWalkingButton();
        }

     [When(@"a user clicks on the Update journey button")]
     public void WhenAUserClicksOnTheUpdateJourneyButton()
        {
            journeyResultPage.ClickUpdateJourneyButton();
        }

        [When(@"a user inputs the To text field with '([^']*)'")]
        public void WhenAUserInputsTheToTextFieldWith(string thomas)
        {
            homepage.InputsIntoTheToField(thomas);
        }

        [Then(@"the journey results page must display '([^']*)' input")]
        public void ThenTheJourneyResultsPageMustDisplayInput(string p0)
        {
            string actualErrorMessage = journeyResultPage.VerifyValidationError();
            Assert.That(actualErrorMessage.Contains(expectedErrorMessage));
        }

        [Then(@"a journey result page showing journey times must be displayed")]
     public void ThenAJourneyResultPageShowingJourneyTimesMustBeDisplayed()
        {
            string actualJourneyTimes = journeyResultPage.ValidateJourneyTime();
            Assert.That(actualJourneyTimes.Contains(expectedJourneyTimes));
        }

      [When(@"a user clicks on '([^']*)' on a selected journey")]
     public void WhenAUserClicksOnOnASelectedJourney(string p0)
        {
            homepage.SelectToLocationDropdown();
        }

     [Then(@"a complete access information at the Underground Station should be visible\.")]
     public void ThenACompleteAccessInformationAtTheUndergroundStationShouldBeVisible_()
        {
            string actualDisplayText = journeyResultPage.VerifyVisibilityOfAccessInformation();
            Assert.That(actualDisplayText.Contains(expectedConfirmationText));
        }

     [Then(@"the journey planner page must display '([^']*)' input")]
     public void ThenTheJourneyResultPageMustDisplayInput(string p0)
        {
            string actualErrorMessage = homepage.VerifyFromErrorMessage();
            Assert.That(actualErrorMessage.Contains(expectedErrorMessage));
        }

     [Then(@"a user must get an error message stating '([^']*)' and '([^']*)'")]
      public void ThenAUserMustGetAnErrorMessageStatingAnd(string p0, string p1)
      {
            string actualErrorMessage = homepage.VerifyFromErrorMessage();
            Assert.That(actualErrorMessage.Contains(expectedErrorMessage));
        }


        [BeforeTestRun]
        public static void ReportGenerator()
        {
            var testResultReport = new ExtentV3HtmlReporter(AppDomain.CurrentDomain.BaseDirectory + @"\TestResult.html");
            testResultReport.Config = AventStack.ExtentReports.Reporter.Configuration.Theme;
            report = new ExtentReports();
            
        }

        [AfterTestRun]
        public static void ReportCleaner()
        {
            report.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = report.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterStep]
        public void StepsInTheReport()
        {
            var typeOfStep = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (scenarioContext.TestError == null)
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
            }

            if (scenarioContext.TestError != null)
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
            }
        }

        [AfterScenario]
        public void CloseTFLApplication()
        {
            try
            {
                if (scenarioContext.TestError != null)
                {
                    string scenarioName = scenarioContext.ScenarioInfo.Title;
                    string directory = AppDomain.CurrentDomain.BaseDirectory + @"\ReportScreenshots\";
                    context.TakeScreenshotAtThePointOfTestFailure(directory, scenarioName);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                context.CloseTFLApplication();
            }
        }
    }
}