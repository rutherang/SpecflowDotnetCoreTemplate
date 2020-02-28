using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace Template.MSTest.Hooks
{
    [Binding]
    public class Hooks
    {
        public IWebDriver Driver;
        private readonly TestContext _testContext;
        private readonly ScenarioContext _scenarioContext;
        private const string testResultsFoldeName = "TestResults";
        public Hooks(IWebDriver driver, ScenarioContext scenarioContext,
            TestContext testContext)
        {
            Driver = driver;
            _scenarioContext = scenarioContext;
            _testContext = testContext;

        }

        [AfterStep]
        public void AfterStep()
        {
            var stepInfo = _scenarioContext.StepContext.StepInfo;
            var stepType = stepInfo.StepDefinitionType.ToString();
            var currentScenarioName = _scenarioContext.ScenarioInfo.Title;
            TakeSnapshot($"{stepType}--{stepInfo.Text}", currentScenarioName);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }

        #region Private Methods
        private string TakeSnapshot(string fileName, string scenario)
        {
            string path;
            try
            {
                Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
                var time = DateTime.Now;
                string formattedTime = time.ToString("HHmmss");
                var parentFolderPath = $"{Directory.GetCurrentDirectory()}/{testResultsFoldeName}";
                CreateFolderIfNotExist(parentFolderPath);
                var folderPath = $"{parentFolderPath}/{ReplaceInvalidChars(scenario)}";
                CreateFolderIfNotExist(folderPath);
                fileName = ReplaceInvalidChars(fileName);
                path = $"{folderPath}/{formattedTime}-{fileName}.png";
                ss.SaveAsFile(path);
                _testContext.AddResultFile(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return path;
        }

        private void CreateFolderIfNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private string ReplaceInvalidChars(string filename)
        {
            var maxChar = 40;
            var cleaned = string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
            cleaned.Replace(" ", "");
            var max = cleaned.Length < maxChar ? cleaned.Length - 1 : maxChar;
            return cleaned.Substring(0, max);
        }
        #endregion
    }
}
