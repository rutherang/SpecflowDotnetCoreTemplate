using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Template.MSTest.StepDefinitions
{
    [Binding]
    public class YahooSteps
    {
        public IWebDriver _driver;

        public YahooSteps(IWebDriver driver)
        {
            _driver = driver;
        }
        [Given(@"I visit yahoo page")]
        public void GivenIVisitYahooPage()
        {
            _driver.Navigate().GoToUrl("https://ph.yahoo.com/");
        }

        [When(@"I type '(.*)' in yahoo search bar")]
        public void WhenITypeInYahooSearchBar(string query)
        {
            var q = _driver.FindElement(By.Id("uh-search-box"));
            q.SendKeys(query);
        }

        [When(@"I click yahoo search")]
        public void WhenIClickYahooSearch()
        {
            var btn = _driver.FindElement(By.Id("uh-search-button"));
            btn.Click();
        }

        [Then(@"I wait for (.*) seconds")]
        public void ThenIWaitForSeconds(int waitTime)
        {
            System.Threading.Thread.Sleep(waitTime);
        }

    }
}
