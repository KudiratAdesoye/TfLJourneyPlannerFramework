namespace TfLCodingChallengeAutomation.StepDefinition
{
    internal class ExtentV3HtmlReporter
    {
        private string v;

        public ExtentV3HtmlReporter(string v)
        {
            this.v = v;
        }

        public object Config { get; internal set; }
    }
}