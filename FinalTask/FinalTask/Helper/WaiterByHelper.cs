using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalTask.Helper
{
    public static class WaiterByHelper
    {
        public static bool WaiterByElementIsDisplayed(this IWebDriver driver, By byClass, int milliseconds)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(nameof(driver), "driver is null");
            }

            var waiter = new WebDriverWait(driver, TimeSpan.FromMilliseconds(milliseconds));

            var element = waiter.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(byClass);
                    return elementToBeDisplayed.Displayed;
                }
                catch (InvalidElementStateException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            return element;
        }

        public static bool WaiterByElementIsNotDisplayed(this IWebDriver driver, By byClass, int milliseconds)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(nameof(driver), "driver is null");
            }

            var waiter = new WebDriverWait(driver, TimeSpan.FromMilliseconds(milliseconds));

            var element = waiter.Until(condition =>
            {
                try
                {
                    ReadOnlyCollection<IWebElement> elementToBeDisplayed = driver.FindElements(byClass);
                    return elementToBeDisplayed.Count == 0;
                }
                catch (InvalidElementStateException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            return element;
        }
    }
}