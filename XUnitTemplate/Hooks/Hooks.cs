using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace XUnitSpecflow.Hooks
{
    [Binding]
    public class Hooks
    {
        public IWebDriver Driver;
        private readonly ITestOutputHelper _output;

        public Hooks(IWebDriver driver, ITestOutputHelper output)
        {
            Driver = driver;
            _output = output;
        }

        [AfterStep]
        public void AfterStep()
        {

        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}
