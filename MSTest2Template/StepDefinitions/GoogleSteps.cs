using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Template.MSTest.StepDefinitions
{
    [Binding]
    public class GoogleSteps
    {
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;

        public GoogleSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I visit google page")]
        public void GivenIVisitGooglePage()
        {
            _driver.Navigate().GoToUrl("https://www.google.com");
        }

        [When(@"I type '(.*)' in search bar")]
        public void WhenITypeInSearchBar(string keyword)
        {
            var q = _driver.FindElement(By.Name("q"));
            q.SendKeys(keyword);
        }

        [When(@"I click search")]
        public void WhenIClickSearch()
        {
            var s = _driver.FindElement(By.Name("btnK"));
            s.Click();
        }


        [Then(@"I see '(.*)' in search results")]
        public void ThenISeeInSearchResults(string searchResult)
        {
            System.Threading.Thread.Sleep(5000);
            var results = _driver.FindElement(By.CssSelector("#appbar"));
            var canSeeResults = results.Text.Contains(searchResult);
            Assert.IsTrue(canSeeResults);
        }

    }
}
