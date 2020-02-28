using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Template.MSTest.Hooks
{
    [Binding]
    public class DriverSetup
    {
        private IObjectContainer _objectContainer;
        public IWebDriver Driver;

        public DriverSetup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var cOptions = new ChromeOptions();
            cOptions.AddArguments("-no-sandbox");
            cOptions.AddArguments("ignore-certificate-errors");

            Driver = new ChromeDriver(cOptions);
            Driver.Manage().Window.Size = new System.Drawing.Size(1440, 900);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _objectContainer.RegisterInstanceAs(Driver);
        }
    }
}
