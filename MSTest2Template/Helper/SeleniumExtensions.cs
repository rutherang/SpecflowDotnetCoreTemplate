using OpenQA.Selenium;
using System;

namespace Template.MSTest.Helper
{
    public static class SeleniumExtensions
    {
        public static void JsClick(this IWebElement webElement, IWebDriver driver)
        {
            if (webElement == null)
                throw new NullReferenceException("Web element is null");

            var js = driver as IJavaScriptExecutor;
            if (js == null)
                throw new InvalidCastException("Failed to cast web driver to javascript executor");

            js.ExecuteScript("return arguments[0].click()", webElement);
        }

        public static string InnerText(this IWebElement webElement, IWebDriver driver)
        {
            try
            {
                if (webElement == null)
                {
                    throw new InvalidElementStateException("Element is null or empty");
                }

                var innerTextAttr = webElement.GetAttribute("innerText");
                if (!string.IsNullOrEmpty(innerTextAttr))
                {
                    return innerTextAttr.Trim();
                }

                var js = driver as IJavaScriptExecutor;
                if (js == null)
                {
                    return null;
                }

                var jsResult = (string)js.ExecuteScript("return arguments[0].innerHTML;", webElement);
                if (string.IsNullOrEmpty(jsResult))
                {
                    return null;
                }

                return jsResult.Trim();
            }
            catch
            {
                return null;
            }
        }
    }
}
